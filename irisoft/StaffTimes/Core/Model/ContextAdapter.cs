using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Core.Model
{
    public class ContextAdapter 
    {
        private StaffTimeDbContainer _dbContainer;

        public ContextAdapter() : this(new StaffTimeDbContainer())
        {
        }

        public ContextAdapter(StaffTimeDbContainer dbContainer)
        {
            _dbContainer = dbContainer;
        }

        #region Work with DataTables


        public DataTable GetDataTable(List<string> fields, string tableName, params int[] iDs)
        {
            string selectF = fields.Aggregate("", (current, field) => current + (", " + field)).Trim(',');

            string idString = iDs.Aggregate("", (current, id) => current + (", " + id)).Trim(',').Trim();

            var table = new DataTable(tableName);
            var cmd = _dbContainer.Database.Connection.CreateCommand();
            cmd.CommandText = $"Select {selectF} from [{tableName}] " +
                              (idString.Length == 0 ? "" : $"where id in ({idString})"); // условия на идентификаторы
            try
            {
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());

            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }

        public void SaveDataTable(DataTable myDataTable)
        {
            using (SqlConnection connection = new SqlConnection(_dbContainer.Database.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        foreach (DataColumn c in myDataTable.Columns)
                            bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                        bulkCopy.DestinationTableName = myDataTable.TableName;

                        bulkCopy.WriteToServer(myDataTable);

                    }

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion


        public bool GreateOrUpdateRow<TTargetObj>(DataRowView drw, bool isNewRow) where TTargetObj : class, IModelSupp
        {
            var dbSet = _dbContainer.Set<TTargetObj>();
            if (isNewRow)
            {
                //var targetObj = ((System.Data.Entity.Infrastructure.IObjectContextAdapter) _repository).ObjectContext.CreateObject<Project>();
                //var target = new Project();
                var targetObj = dbSet.Create();
                try
                {
                    SetValues(drw, targetObj);
                    dbSet.Add(targetObj);
                    _dbContainer.SaveChanges();

                }
                catch (DbEntityValidationException exValid)
                {
                    ShowInvalidDatas<TTargetObj>();
                    dbSet.Remove(targetObj);
                    //throw;
                    return false;
                }
                catch
                {
                    dbSet.Remove(targetObj);
                    //throw;
                    return false;
                }
            }
            else
            {
                try
                {
                    int i = (int) drw["Id"];
                    var pEditable = dbSet.FirstOrDefault(p => p.Id == i);
                    SetValues(drw, pEditable);
                    _dbContainer.SaveChanges();
                }
                catch (DbEntityValidationException exValid)
                {
                    ShowInvalidDatas<TTargetObj>();
                    //throw;

                    return false;
                }
            }
            return true;
        }

        private static void ShowInvalidDatas<TTargetObj>() where TTargetObj : class, IModelSupp
        {
            //MessageBox.Show("Исправьте не верно введеные данные!" + Environment.NewLine + "Сохранение невозможно.", "Данные не валидны", MessageBoxButtons.OK);
        }


        public DataTable GetDataTableUser(bool modifyId = false)
        {
            var fields = new List<string> { modifyId? "Id as UserId" : "Id", "UserName", "Login", "Password", "Role" };
            var dataTable = GetDataTable(fields, "User");
            return dataTable;
        }

        public DataTable GetDataTableProjects(params int[] projectIds)
        {
            var fields = new List<string> { "Id as ProjectId", "ProjectName", "Description" };
            var dataTable = GetDataTable(fields, "Project", projectIds);
            //dataTable.Columns.Add("ProjectId");
            return dataTable;
        }

        public static void SetValues(DataRowView rawRow, IModelSupp targetObj)
        {
            foreach (var property in targetObj.GetType().GetProperties())
            {
                if (rawRow.Row.Table.Columns.Contains(property.Name))
                {
                    var value = rawRow[property.Name];
                    if (value != DBNull.Value)
                        property.SetValue(targetObj, value, null);
                }
            }
        }

        public void Update()
        {
            _dbContainer.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Task> Tasks => _dbContainer.Task;

        public IQueryable<ActiveProjectOnStaff> ActiveProjectOnStaff(User currentUser) => _dbContainer.ActiveProjectOnStaffSet.Where(act => act.UserId == currentUser.Id);

        public DbSet<Project> Projects => _dbContainer.Project;

        public void Delete<T>(int i) where T: class, IModelSupp
        {
            var dbSet = _dbContainer.Set<T>();
            var itemT = dbSet.FirstOrDefault(t => t.Id == i);
            if (itemT != null)
            {
                _dbContainer.Entry(itemT).State = EntityState.Deleted;
                dbSet.Remove(itemT);
            }
            _dbContainer.SaveChanges(); 
        }

        public DateTime? GetDateOfLock()
        {
            using (var staffTimeDbContainer = new StaffTimeDbContainer())
            {
                var property = staffTimeDbContainer.PropertySet.FirstOrDefault(p => p.Key == "DateOfLock");
                if (property != null)
                    return Convert.ToDateTime(property.Value);
                return null;
            }
        }
    }
}
