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
            //Speaker.Instance().CanBeInteresting += speaker_lauf;
            RunStrategy();
            //var stopWorld = string.Empty;
            //var strategy = new MacDStrategy();
            //while (stopWorld != "stop")
            //{
            //    Thread.Sleep(500);
            //    RunStrategy();
            //    //stopWorld = Console.ReadLine();
            //    //if(stopWorld == "restart")
            //    {
            //        var str = strategy.ToString();
            //        //Task.Factory.StartNew(RunStrategy);
            //    }
            //}
        }
        private static void RunStrategy()
        {
            var strategy = new MacDStrategy();
            var param = new ParametersForTestStrategy()
            {
                start = new DateTime(2020, 12, 1),
                end = new DateTime(2021, 01, 1),
                pair = "EthUsdt",
                period = TimeInterval.Hours_1,
                FirstVolume = 1,
            };

            var res = strategy.TestFromDbForPeriod(param);
        }

        private static async Task RunStrategyAsync()
        {
            var strategy = new MacDStrategy();
            var param = new ParametersForTestStrategy()
            {
                start = new DateTime(2020, 12, 1),
                //end = new DateTime(2019, 01, 1),
                pair = "EthUsdt",
                period = TimeInterval.Hours_1,
                FirstVolume = 1,
            };
            var res = await strategy.TestForPeriodAsync(param);
        }

        private static void speaker_lauf(object sender, MessageEventArg e)
        {
            Console.WriteLine($"{e.Level.ToString()}: {e.Message}");
        }

    }
}
