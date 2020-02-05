﻿using System;
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

        public ContextAdapter() : this(new StaffTimesContainer())
        {
        }

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
                try
                {
                    SetValues(drw, targetObj);
                    dbSet.Add(targetObj);
                    _dbContainer.SaveChanges();

                }
                catch (Exception e)
                {
                    //_dbContainer.Set<TTargetObj>().dettach
                    throw;
                }
                finally
                {
                    
                }
            }
            else
            {
                int i = (int) drw["Id"];
                var pEditable = dbSet.FirstOrDefault(p => p.Id == i);
                SetValues(drw, pEditable);
                _dbContainer.SaveChanges();
            }
        }

        public object GetDataTableTasks(int userId, DateTime from, DateTime to, params int[] projectIds)
        {
            var idsEmptyProjs = projectIds.Length == 0;
            var tasks = _dbContainer.Task.Where(t =>
                (userId < 0 || t.UserId == userId) &&
                (idsEmptyProjs || projectIds.Contains(t.ProjectId) && t.Date >= from && t.Date <= to)).ToList();
            Dictionary<int, string> usersDic = new Dictionary<int, string>();
            foreach (var task in tasks)
            {
                if (!usersDic.ContainsKey(task.UserId))
                {
                    usersDic.Add(task.UserId, task.User.UserName);
                }
            }
            var fields = new List<string> { "Id", "UserId", "ProjectId", "Date", "Duration", "Comment" };
            var dataTable = _dbContainer.GetDataTable(fields, "Task", tasks.Select(t=>t.Id).ToArray());
            dataTable.Columns.Add("UserName");
            //dataTable.Columns.Add("ProjectName");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (int.TryParse(dataRow["UserId"] as string, out var userid))
                {
                    dataRow["UserName"] = usersDic[userid];
                }
            }
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
                        property.SetValue(targetObj, value);
                }
            }
        }

        public void Update()
        {
            _dbContainer.SaveChanges();
        }

        public IList<Project> GetSelectProjects(params int[] ids)
        {
            var idsEmpty = ids.Length == 0;
            return _dbContainer.Project.Where(p => idsEmpty || ids.Contains(p.Id)).ToList();
        }
    }
}
