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


        internal Tuple<DateTime, int> CalcNewDate(int idUser)
        {
            DateTime startDate = _dateOfLock.HasValue && _dateOfLock.Value >= StartDate ? _dateOfLock.Value.AddDays(1) : StartDate; // ограничим снизу датой блокировки

            DateTime endDate = EndDate > DateTime.Today ? DateTime.Today : EndDate;

            IList<Task> tasks = DbAdapter.Tasks.Where(t => t.UserId == idUser && t.Date >= startDate && t.Date <= endDate).ToList();
            int sumdaily = -1;
            DateTime lastDate = DateTime.Today;
            foreach (var task in tasks.OrderBy(t => t.Date))
            {
                if (sumdaily == -1) // первый прогон
                {
                    lastDate = task.Date;
                    sumdaily = task.Duration;
                }
                else if (lastDate == task.Date)
                {
                    sumdaily += task.Duration;
                }
                else if (sumdaily < 8)
                {
                    return new Tuple<DateTime, int>(lastDate, 8 - sumdaily);
                }
                else
                {
                    lastDate = task.Date;
                    sumdaily = task.Duration;
                }
            }
            if (sumdaily != -1)
            {
                if (sumdaily == 8) // полный день , передвигаем относительно последнего исследованного
                {
                    if (lastDate.DayOfWeek == DayOfWeek.Friday)
                        lastDate = lastDate.AddDays(3); // перескакиваем выходные
                    else
                    {
                        lastDate = lastDate.AddDays(1); // берем следующий день
                    }
                    return new Tuple<DateTime, int>(lastDate, sumdaily);
                }
                else
                {
                    return new Tuple<DateTime, int>(lastDate, sumdaily < 8 ? (8 - sumdaily) : sumdaily > 8 ? 8 : sumdaily);
                }
            }
            else
            {
                return new Tuple<DateTime, int>(lastDate, 8);
            }
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
        SortedSet<int> _readOnlyRows = new SortedSet<int>();

        public DateTime? GetDateOfLock(bool needRefresh = false)
        {
            if(needRefresh)
                _dateOfLock = DbAdapter.GetDateOfLock();
            return _dateOfLock;
        }

        internal bool FocusedRowIsReadOnly(int rowhandle)
        {
            return _readOnlyRows.Contains(rowhandle);
        }

        /// <summary>
        ///  если строка была уже помечена как readOnly = снимаем или подтверждаем
        /// если надо пометить, добавляем в коллекцию
        /// </summary>
        /// <param name="eRowHandle"></param>
        /// <param name="rowIsReadOnly"></param>
        public void SetReadOnlyRowHandle(int eRowHandle, bool rowIsReadOnly)
        {
            if (rowIsReadOnly && !_readOnlyRows.Contains(eRowHandle))
            {
                _readOnlyRows.Add(eRowHandle);
            }
            else if (!rowIsReadOnly && _readOnlyRows.Contains(eRowHandle))
            {
                _readOnlyRows.Remove(eRowHandle);
            }
        }

        #endregion

        public void DeleteTask(int id)
        {
            DbAdapter.Delete<Task>(id);
        }

        public DataTable GetDataTableTasks()
        {

            var userId = IsAdmin && ShowAllUsers ? -1 : UserId;
            var tableTasks = GetDataTableTasks(userId, StartDate, EndDate);
            return tableTasks;
        }

        private DataTable GetDataTableTasks(int userId, DateTime from, DateTime to, params int[] projectIds)
        {
            var idsEmptyProjs = projectIds.Length == 0;
            var tasks = DbAdapter.Tasks.Where(t =>
                (userId < 0 || t.UserId == userId) &&
                (idsEmptyProjs || projectIds.Contains(t.ProjectId)) && t.Date >= from && t.Date <= to).ToList();

            Dictionary<DateTime, StateTaskEnum> states = GetDictStatesTask(tasks);

            var fields = new List<string> { "Id", "UserId", "ProjectId", "Date", "Duration", "Comment" };
            int[] arrUserId = tasks.Any() ? tasks.Select(t => t.Id).ToArray() : new[] { -1 };
            var tableTasks = DbAdapter.GetDataTable(fields, "Task", arrUserId);

            tableTasks.Columns.Add("StateTask", typeof(StateTaskEnum));

            foreach (DataRow row in tableTasks.Rows)
            {
                var date = Convert.ToDateTime(row["Date"]);
                row["StateTask"] = states[date];
            }
            return tableTasks;
        }

        private Dictionary<DateTime, StateTaskEnum> GetDictStatesTask(List<Task> tasks)
        {
            Dictionary<DateTime, StateTaskEnum> result = new Dictionary<DateTime, StateTaskEnum>();
            var grouppedBy = tasks.GroupBy(t => t.Date);
            var date = GetDateOfLock();
            foreach (IGrouping<DateTime, Task> group in grouppedBy)
            {
                if (date.HasValue && group.Key <= date)
                {
                    result.Add(group.Key, StateTaskEnum.ReadOnly);
                }
                else
                {
                    var sumDurations = group.Sum(t => t.Duration);
                    if(sumDurations < 8)
                        result.Add(group.Key, StateTaskEnum.LessThenNecessary);
                    else if (sumDurations == 8)
                        result.Add(group.Key, StateTaskEnum.Normal);
                    else if (sumDurations > 8)
                        result.Add(group.Key, StateTaskEnum.MoreThenNecessary);
                }
            }
            return result;
        }

        public bool ValidateTask(DataRowView drw, bool isNewRow)
        {
            return DbAdapter.GreateOrUpdateRow<Task>(drw, isNewRow);
        }


    }

    internal enum StateTaskEnum
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