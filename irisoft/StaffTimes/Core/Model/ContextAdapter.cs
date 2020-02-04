using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ContextAdapter 
    {
        private StaffTimesContainer _dbContainer;

        public ContextAdapter(StaffTimesContainer dbContainer)
        {
            _dbContainer = dbContainer;
        }


        public void SetAndUpdateProject(DataRowView drw, bool isNewRow)
        {
            GreateOrUpdateRow(drw, isNewRow, _dbContainer.Project);
        }
        public void SetAndUpdateTask(DataRowView drw, bool isNewRow)
        {
            GreateOrUpdateRow(drw, isNewRow, _dbContainer.Task);
        }
        public void SetAndUpdateUser(DataRowView drw, bool isNewRow)
        {
            GreateOrUpdateRow(drw, isNewRow, _dbContainer.User);
        }

        private void GreateOrUpdateRow<TTargetObj>(DataRowView drw, bool isNewRow, DbSet<TTargetObj> dbSet) where TTargetObj : class, IModelSupp
        {
            if (isNewRow)
            {
                //var targetObj = ((System.Data.Entity.Infrastructure.IObjectContextAdapter) _repository).ObjectContext.CreateObject<Project>();
                //var target = new Project();
                var targetObj = dbSet.Create();
                SetValues(drw, targetObj);
                dbSet.Add(targetObj);
                _dbContainer.SaveChanges();
            }
            else
            {
                int i = (int) drw["Id"];
                var pEditable = dbSet.FirstOrDefault(p => p.Id == i);
                SetValues(drw, pEditable);
                _dbContainer.SaveChanges();
            }
        }

        public object GetDataTableUser()
        {
            var fields = new List<string> { "Id", "UserName", "Login", "Password", "Role" };
            var dataTable = _dbContainer.GetDataTable(fields, "User");
            return dataTable;
        }

        public object GetDataTableProjects()
        {
            var fields = new List<string> { "Id", "ProjectName", "Description" };
            var dataTable = _dbContainer.GetDataTable(fields, "Project");
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
                        property.SetValue(targetObj, value);
                }
            }
        }

        public void Update()
        {
            _dbContainer.SaveChanges();
        }
    }
}
