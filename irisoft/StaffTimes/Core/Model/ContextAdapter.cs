using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    _dbContainer.Entry(targetObj).State = EntityState.Added;
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

                    dbSet.Load();
                    var pEditable = dbSet.Where(p => p.Id == i).FirstOrDefault();
                    
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


        public DataTable GetDataTableTasks(int userId, DateTime from, DateTime to, params int[] projectIds)
        {
            var idsEmptyProjs = projectIds.Length == 0;
            var tasks = Tasks.Where(t =>
                (userId < 0 || t.UserId == userId) &&
                (idsEmptyProjs || projectIds.Contains(t.ProjectId)) && t.Date >= from && t.Date <= to).ToList();


            var fields = new List<string> { "Id", "UserId", "ProjectId", "Date", "Duration", "Comment" };
            int[] arrUserId = tasks.Any() ? tasks.Select(t => t.Id).ToArray() : new[] { -1 };
            var tableTasks = GetDataTable(fields, "Task", arrUserId);

            tableTasks.Columns.Add("StateTask", typeof(StateTaskEnum));

            RecalcStatesTask(tableTasks);

            return tableTasks;
        }

        internal void RecalcStatesTask(DataTable tasks)
        {
            Dictionary<DateTime, StateTaskEnum> states = new Dictionary<DateTime, StateTaskEnum>();
            var grouppedBy = tasks.Rows.Cast<DataRow>().GroupBy(t => t["Date"]);
            var dateLock = GetDateOfLock();
            foreach (IGrouping<object, DataRow> group in grouppedBy)
            {
                var groupKey = Convert.ToDateTime(group.Key);
                if (dateLock.HasValue && groupKey <= dateLock)
                {
                    states.Add(groupKey, StateTaskEnum.ReadOnly);
                }
                else
                {
                    var sumDurations = group.Sum(t => (int)t["Duration"]);
                    if (sumDurations < 8)
                        states.Add(groupKey, StateTaskEnum.LessThenNecessary);
                    else if (sumDurations == 8)
                        states.Add(groupKey, StateTaskEnum.Normal);
                    else if (sumDurations > 8)
                        states.Add(groupKey, StateTaskEnum.MoreThenNecessary);
                }
            }

            foreach (DataRow row in tasks.Rows)
            {
                var date = Convert.ToDateTime(row["Date"]);
                row["StateTask"] = states[date];
            }
        }

    }

    public enum StateTaskEnum
    {
        [Description("Неопределенное состояние строки")]
        Unknow,
        [Description("Только для чтения")]
        ReadOnly,
        [Description("Меньше, чем необходимо")]
        LessThenNecessary,
        [Description("Отлично!")]
        Normal,
        [Description("Больше, чем необходимо")]
        MoreThenNecessary,

    }
}
