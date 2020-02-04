using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
 
    public partial class User
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
    /*
   public partial class Day
    {
        public ColorEnum Status
        {
            get
            {
                int summ = Tasks.Sum(t => t.Duration);
                if (summ == ExpectedDuration)
                {
                    return ColorEnum.Green;
                }
                return ColorEnum.Red;
            }
        }

        public int ExpectedDuration { get; set; }

        public override string ToString()
        {
            return $"Неделя: {GetDurationDates()} {Status}";
        }

        private string GetDurationDates()
        {
            var cal = new GregorianCalendar();
            var weekNumber = cal.GetWeekOfYear(Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            var beginDateOfWeek = GetBeginDateOfWeek(weekNumber);
            var lastDateOfWeek = beginDateOfWeek.AddDays(6);
            return $"{beginDateOfWeek.ToString("M")} - {lastDateOfWeek.ToString("M")}";
        }

        public static DateTime GetBeginDateOfWeek(int weekNumber)
        {
            DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1); //1 января сего года
            while (firstDay.DayOfWeek != DayOfWeek.Monday) firstDay = firstDay.AddDays(-1); //ближайший предыдущий понедельник
            return firstDay.AddDays(7 * weekNumber); //добавляем количество недель * 7 дней
        }

    }*/


    public enum ColorEnum
    {
        Gray = 1,
        Green,
        Yellow,
        Orange,
        Red
    }

}
