using AnalyticalCenter.Helpers;
using AnalyticalCenter.Strategy;
using Binance.API.Csharp.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(RunStrategy);
            var stopWorld = string.Empty;
            while (stopWorld != "stop")
            {
                Thread.Sleep(500);
                stopWorld = Console.ReadLine();
                if(stopWorld == "restart")
                {
                    Task.Factory.StartNew(RunStrategy);
                }
            }
        }


        private static async Task RunStrategy()
        {
            Speaker.Instance().CanBeInteresting += speaker_lauf; 
            var strategy = new MacDStrategy();
            var res = await strategy.TestForPeriodAsync(new DateTime(2019, 12, 31), null, TimeInterval.Days_1);
        }

        private static void speaker_lauf(object sender, MessageEventArg e)
        {
            Console.WriteLine($"{e.Level.ToString()}: {e.Message}");
        }
    }
}
