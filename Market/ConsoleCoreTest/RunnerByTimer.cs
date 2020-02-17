using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleCoreTest
{
    public class RunnerByTimer
    {
        public EventHandler LoggerDelegate;

        public void OnLoggerDelegate(string message)
        {
            LoggerDelegate?.Invoke(message, EventArgs.Empty);
        }

        /// <summary> Занятость апдейтера </summary>
        public bool Busy { get; set; }

        /// <summary>
        /// Проверка настроек 
        /// </summary>
        public RunnerByTimer()
        {
            OnLoggerDelegate("приступим");
            new Timer(ValidateProperty, this, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 2));
        }

        private static void ValidateProperty(object state)
        {
            var updater = (RunnerByTimer) state;
            updater.OnLoggerDelegate("вошли в метод");
            if (!updater.Busy)
            {
                updater.OnLoggerDelegate($"состояние {updater.Busy}");
                updater.Busy = true;
                var now = DateTime.Now.Trim(TimeSpan.TicksPerSecond);
                var prop = IntegrationWithExternalLisProperty.Load();

                updater.OnLoggerDelegate($"свойство {prop.TimeNextConnectToExternalLis}");
                if (prop.TimeNextConnectToExternalLis <= now)
                {
                    if (updater.OnServiceConnectToExternalLis())
                    {
                        prop.TimeNextConnectToExternalLis = DateTime.Now.Trim(TimeSpan.TicksPerSecond);
                        updater.OnLoggerDelegate($"запуск метода Update");
                        prop.Update();
                    }
                }
                updater.OnLoggerDelegate($"состояние {updater.Busy}");
                updater.Busy = false;
            }
            else
            {
                updater.OnLoggerDelegate($"\t\t\t обошли выполнение, в связи с состоянием {updater.Busy}");
            }
        }

        public bool OnServiceConnectToExternalLis()
        {
            OnLoggerDelegate($"запуск метода OnServiceConnectToExternalLis");
            Thread.Sleep(3000);
            OnLoggerDelegate($"остановка метода OnServiceConnectToExternalLis");
            return true;
        }
    }
}