using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;

namespace Core
{
 
    public partial class User : IModelSupp
    {
        public override string ToString()
        {
            return $"{UserName } ({Login}) {Role}";
        }

        public int GetLastWeekNumber()
        {
            //Day last = null;
            //using (var repository = new ModelCont())
            {
                
                //var collection = Weeks.ToList();
               // last = repository.Day.Where(w => w.UserId == Id).OrderByDescending(w => w.Date).FirstOrDefault();
            }
//            if (last != null)
//                return last.WeekNumber;
            var cal = new GregorianCalendar();
            var weekNumber = cal.GetWeekOfYear(DateTime.Today.AddDays(-13), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNumber;
        }
    }
    
    public partial class Project : IModelSupp
    {
        public override string ToString()
        {
            return ProjectName;
        }
    }

    public partial class Task : IModelSupp
    {

        public virtual string ProjectName => Project?.ProjectName;

        public override string ToString()
        {
            return $"{User} ({Duration}) {Date:M}";
        }
    }

    public enum ColorEnum
    {
        Gray = 1,
        Green,
        Yellow,
        Orange,
        Red
    }

}
