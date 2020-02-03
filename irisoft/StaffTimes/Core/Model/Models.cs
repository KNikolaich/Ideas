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
        public RoleEnum GetRoleEnum()
        {
            return (RoleEnum)Role;
        }
        public override string ToString()
        {
            return $"{UserName } ({Login}) {GetRoleEnum()}";
        }
    }

    public partial class Week
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
            var weekNumber = cal.GetWeekOfYear(EditStarted, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
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
