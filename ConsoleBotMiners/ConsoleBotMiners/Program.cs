﻿using System;
using System.Threading;
using System.Threading.Tasks;
using BotCore;

namespace ConsoleBotMiners
{
    class Program
    {
        static void Main(string[] args)
        {
            var monitor = new MinersMonitor();
            while (true)
            {
                Thread.Sleep(5000);
                monitor.ValidatePools();
            }

            Console.ReadLine();
        }

        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configuration =>
                {
                    configuration....;
                });
            .ConfigureServices((hostContext, services) =>
        {
            var myConfigurationSection = configuration.GetSection("app");

            services.AddSingleton<IValidateOptions<AppOptions>, AppOptionsValidator>();
            services.Configure<AppOptions>(myConfigurationSection);

        });*/
    }
}
