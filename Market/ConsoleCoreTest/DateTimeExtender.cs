using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCoreTest
{
    static class DateTimeExtender
    {

        /// <summary>
        /// Округление до заданного значения
        /// </summary>
        /// <param name="date"></param>
        /// <param name="roundTicks"></param>
        /// <returns></returns>
        public static DateTime Trim(this DateTime date, long roundTicks)
        {
            return new DateTime(date.Ticks - date.Ticks % roundTicks);
        }
    }
}
