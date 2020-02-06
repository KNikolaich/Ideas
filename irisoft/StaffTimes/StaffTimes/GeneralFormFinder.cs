using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using System.Threading.Tasks;
using Core.Model;
using Task = Core.Task;


namespace StaffTimes
{
    /// <summary>
    /// Ассистент для переноски временных данных для поиска
    /// </summary>
    public class GeneralFormFinder
    {
        internal GeneralFormFinder()
        {
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
        public ContextAdapter Db { get; set; }


        internal Tuple<DateTime, int> CalcNewDate(int idUser)
        {
            IList<Task> tasks = Db.Tasks.Where(t => t.UserId == idUser && t.Date >= StartDate && t.Date <= EndDate).ToList();
            int sumdaily = -1;
            DateTime lastDate = DateTime.Today;
            foreach (var task in tasks.OrderBy(t=>t.Date))
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
                    return new Tuple<DateTime, int>(lastDate, 8-sumdaily);
                }
                else
                {

                    lastDate = task.Date;
                    sumdaily = task.Duration;
                }

            }
            if (sumdaily != -1)
            {
                if (lastDate.DayOfWeek == DayOfWeek.Friday)
                    lastDate = lastDate.AddDays(3); // перескакиваем выходные
                else
                    lastDate = lastDate.AddDays(1); // берем следующий день
            }
            else
            {
                sumdaily = 0;
            }
            return new Tuple<DateTime, int>(lastDate, 8 - sumdaily);
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


        public IList<Project> GetSelectProjects(params int[] ids)
        {
            var idsEmpty = ids.Length == 0;
            return Db.Projects.Where(p => idsEmpty || ids.Contains(p.Id)).ToList();
        }

        public void RecalcActiveProjects()
        {
            var queryable = Db.ActiveProjectOnStaff(CurrentUser).Select(act => act.ProjectId);
            ProjectIds = queryable.ToList();
        }
    }
}
