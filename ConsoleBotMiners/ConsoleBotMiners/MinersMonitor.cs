using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BotCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using NanopoolApi;
using System.Web.Script.Serialization;

namespace ConsoleBotMiners
{
    /// <summary>
    /// Монитор майнеров
    /// </summary>
    class MinersMonitor
    {
        private Sender _senderBot;

        readonly Nanopool _nanopoolEth = new Nanopool(Statics.PoolType.ETH);
        readonly Nanopool _nanopoolXmr = new Nanopool(Statics.PoolType.XMR);
        private IConfigurationRoot _conf;

        private DateTime _lasTime = DateTime.Now;

        public MinersMonitor()
        {
            _senderBot = new Sender();
   
        }

        public IConfiguration GetConfiguration()
        {
            if (_conf == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json");

                // создаем конфигурацию
                _conf = builder.Build();
            }

            return _conf;
        }

        /// <summary> Проверка пулов </summary>
        public void ValidatePools()
        {
            if (_lasTime.AddMinutes(30) > DateTime.Now) // проверка осуществляется не чаще чем раз  впол часа
            {
                _lasTime = DateTime.Now;

                var configuration = GetConfiguration();
                var xmrWall = configuration["Wallets:xmr"];
                var hashrate = _nanopoolXmr.GetAverageHashrate(xmrWall);
                if (Equals(hashrate.Data.H3, 0f))
                {
                    Task.Factory.StartNew(() => _senderBot.SendMessage("xmr 0 выработки"));
                    Console.WriteLine("xmr 0 выработки");
                }


                using (Process compiler = new Process())
                {
                    compiler.StartInfo.FileName = "ClientPool.exe";
                    compiler.StartInfo.Arguments =
                        "https://api.ethermine.org/miner/0x85cFc2bBb112De8c36401F61041D14b2B97b66c0/currentStats averageHashrate";
                    compiler.StartInfo.UseShellExecute = false;
                    compiler.StartInfo.RedirectStandardOutput = true;
                    compiler.Start();

                    var readToEnd = compiler.StandardOutput.ReadToEnd();
                    if (decimal.TryParse(readToEnd, out var res) && res == 0)
                    {
                        Task.Factory.StartNew(() => _senderBot.SendMessage("eth 0 выработки"));
                        Console.WriteLine("eth 0 выработки");
                    }

                    compiler.WaitForExit();
                }
            }
        }
    }
}
