using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public object GetDataTableTasks(int userId, DateTime from, DateTime to, params int[] projectIds)
        {
            var idsEmptyProjs = projectIds.Length == 0;
            var tasks = _dbContainer.Task.Where(t =>
                (userId < 0 || t.UserId == userId) &&
                (idsEmptyProjs || projectIds.Contains(t.ProjectId)) && t.Date >= from && t.Date <= to).ToList();
            
            var fields = new List<string> { "Id", "UserId", "ProjectId", "Date", "Duration", "Comment" };
            int[] arrUserId = tasks.Any()? tasks.Select(t=>t.Id).ToArray() : new []{-1};
            var dataTable = _dbContainer.GetDataTable(fields, "Task", arrUserId);
            return dataTable;
        }

        public object GetDataTableUser(bool modifyId = false)
        {
            var fields = new List<string> { modifyId? "Id as UserId" : "Id", "UserName", "Login", "Password", "Role" };
            var dataTable = _dbContainer.GetDataTable(fields, "User");
            return dataTable;
        }

        public object GetDataTableProjects(params int[] projectIds)
        {
            var fields = new List<string> { "Id as ProjectId", "ProjectName", "Description" };
            var dataTable = _dbContainer.GetDataTable(fields, "Project", projectIds);
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
            _dbContainer.Entry(itemT).State = EntityState.Deleted;
            if (itemT != null)
                dbSet.Remove(itemT);
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
