using System;
using Binance.API.Csharp.Client.Models.Enums;

namespace Binance.API.Csharp.Client.Models.Helpers
{
    public static class Converters
    {
        /// <summary>
        /// С сервера приходит double вместо времени, 
        /// его надо прибавить в виде секунд к 1 января 1970 г. (юникс формат) 
        /// и перевести в локальную зону 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GeDateTime(double time)
        {
            var dateTime = new DateTime(1970, 1, 1);
            var dateTimeIntoUtc = dateTime.AddMilliseconds(time);
            return dateTimeIntoUtc.ToLocalTime();
        }

        /// <summary>
        /// Преобразование интервала в TimeSpan
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static TimeSpan IntervalToTimespan(TimeInterval interval)
        {
            switch (interval)
            {
                case TimeInterval.Days_3:

                    return new TimeSpan(3, 0, 0, 0);
                case TimeInterval.Days_1:

                    return new TimeSpan(1, 0, 0, 0);
                case TimeInterval.Hours_12:

                    return new TimeSpan(0, 12, 0, 0);
                case TimeInterval.Hours_8:

                    return new TimeSpan(0, 8, 0, 0);
                case TimeInterval.Hours_6:

                    return new TimeSpan(0, 6, 0, 0);
                case TimeInterval.Hours_4:

                    return new TimeSpan(0, 4, 0, 0);
                case TimeInterval.Hours_2:

                    return new TimeSpan(0, 2, 0, 0);
                case TimeInterval.Hours_1:

                    return new TimeSpan(0, 1, 0, 0);
                case TimeInterval.Minutes_15:

                    return new TimeSpan(0, 0, 15, 0);
                case TimeInterval.Minutes_30:

                    return new TimeSpan(0, 0, 30, 0);
                case TimeInterval.Minutes_5:

                    return new TimeSpan(0, 0, 5, 0);
                case TimeInterval.Minutes_3:

                    return new TimeSpan(0, 0, 3, 0);
                case TimeInterval.Minutes_1:

                    return new TimeSpan(0, 0, 1, 0);

            }
            return new TimeSpan(1, 0, 0, 0);
        }
    }
}
