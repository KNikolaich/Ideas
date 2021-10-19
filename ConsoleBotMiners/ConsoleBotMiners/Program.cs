using System;
using System.Threading;
using System.Threading.Tasks;
using BotCore;

namespace ConsoleBotMiners
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск бота");
            var monitor = new MinersMonitor();
            while (true)
            {
                Thread.Sleep(5000);
                monitor.ValidatePools();
            }

            //Console.ReadLine();
        }

    }
}
