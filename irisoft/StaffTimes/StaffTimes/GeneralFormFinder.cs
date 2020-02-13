using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Core;
using Core.Model;


namespace StaffTimes
{
    /// <summary>
    /// Ассистент для переноски временных данных для поиска
    /// </summary>
    public class GeneralFormFinder
    {
        internal GeneralFormFinder()
        {
            DbAdapter = new ContextAdapter();
            ProjectIds = new List<int>();
            InitDates();
        }

        internal DateTime StartDate { get; set; }

        internal DateTime EndDate { get; set; }

        internal List<int> ProjectIds { get; set; }

        internal int UserId => CurrentUser.Id;

        internal bool IsAdmin => CurrentUser.Role == StaffRole.Admin;

        internal User CurrentUser { get; set; }

        internal bool ShowAllUsers { get; set; }

        private ContextAdapter DbAdapter { get; }



        internal Tuple<DateTime, int> CalcNewDate(DataTable tasks)
        {
            var grouppedBy = tasks.Rows.Cast<DataRow>().OrderBy(t => Convert.ToDateTime(t["Date"]).Ticks).GroupBy(t => t["Date"]);
            var dateLock = GetDateOfLock();
            DateTime maxDate = DateTime.MinValue;
            foreach (IGrouping<object, DataRow> group in grouppedBy)
            {
                var groupDate = Convert.ToDateTime(group.Key);
                if (!dateLock.HasValue || groupDate > dateLock)
                {
                    var sumDurations = group.Sum(t => (int) t["Duration"]);
                    if (sumDurations < 8)
                        return new Tuple<DateTime, int>(groupDate, 8 - sumDurations);

                    if (groupDate > maxDate)
                    {
                        if (maxDate != DateTime.MinValue && (groupDate - maxDate).Days > 1)
                        {
                            if (maxDate.DayOfWeek != DayOfWeek.Friday)
                            {
                                return new Tuple<DateTime, int>(maxDate.AddDays(1), 8);
                            }
                            if ((groupDate - maxDate).Days > 3) // возвращаем понедельник
                            {
                                return new Tuple<DateTime, int>(maxDate.AddDays(3), 8);
                            }

                        }
                            
                        maxDate = groupDate;
                    }

                }
                 
            }
            maxDate = maxDate == DateTime.MinValue ? DateTime.Today : maxDate.AddDays(1);
            return new Tuple<DateTime, int>(maxDate, 8);
        }

        private void InitDates()
        {
            DateTime end = DateTime.Today.AddDays(1);
            DateTime start = DateTime.Today.AddDays(-7);
            DateTime? additionDateTime = end;
            List<DateTime> dtList = new List<DateTime>();
            while (additionDateTime != null)
            {
                dtList.Add(additionDateTime.Value);
                additionDateTime = additionDateTime.Value.AddDays(-1);
                if (additionDateTime <= start && additionDateTime.Value.DayOfWeek == DayOfWeek.Monday
                ) // гоним до понедельника прошлой неделеи
                {
                    additionDateTime = null;
                }
            }
            StartDate = dtList.Min();
            EndDate = dtList.Max();
        }

        public DataTable GetDataTableUser()
        {
            return DbAdapter.GetDataTableUser(true);
        }

        internal DataTable GetDataTableProjects(bool allLoad = false)
        {
            return DbAdapter.GetDataTableProjects(allLoad ? new int[0] : ProjectIds.ToArray());
        }
        public IList<Project> GetSelectProjects(params int[] ids)
        {
            
            var idsEmpty = ids.Length == 0;
            return DbAdapter.Projects.Where(p => idsEmpty || ids.Contains(p.Id)).ToList();
        }

        public void RecalcActiveProjects()
        {
            var queryable = DbAdapter.ActiveProjectOnStaff(CurrentUser).Select(act => act.ProjectId);
            ProjectIds = queryable.ToList();
        }

        #region Для обработки блокировки по дате

        private DateTime? _dateOfLock;

        public DateTime? GetDateOfLock(bool needRefresh = false)
        {
            if(needRefresh)
                _dateOfLock = DbAdapter.GetDateOfLock();
            return _dateOfLock;
        }

        #endregion

        public void DeleteTask(int id)
        {
            DbAdapter.Delete<Task>(id);
        }

        public DataTable GetDataTableTasks()
        {

            var userId = IsAdmin && ShowAllUsers ? -1 : UserId;
            var tableTasks = DbAdapter.GetDataTableTasks(userId, StartDate, EndDate);
            return tableTasks;
        }

        public bool ValidateTask(DataRowView drw, bool isNewRow)
        {
            return DbAdapter.GreateOrUpdateRow<Task>(drw, isNewRow);
        }

        /// <summary> берем либо дату начала, либо дату блокировки в качестве минималки для редактирования </summary>
        /// <returns></returns>
        public DateTime GetMinData()
        {
            return !_dateOfLock.HasValue || _dateOfLock.Value <= StartDate ? StartDate : _dateOfLock.Value.AddDays(1);
        }
    }

}