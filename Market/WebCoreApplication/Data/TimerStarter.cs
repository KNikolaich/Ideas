using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebCoreApplication.Data
{
    public class TimerStarter : ITimerStarter
    {
        Timer _timer = new Timer(60000);
        private static DateTime startDate;
        private static long lIter = 0;


        public TimerStarter()
        {
            startDate = DateTime.Now;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        public static string GetString()
        {
            return $"Старт сервера:{startDate:U}. Прошло минут {lIter:F0}";
        }

        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lIter++;
        }

    }

    public interface ITimerStarter
    {
    }
}
