using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BotCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using NanopoolApi;

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
        public void VelidatePools()
        {
            var configuration = GetConfiguration();
            var xmrWall = configuration["Wallets:xmr"];
            var hashrate = _nanopoolXmr.GetAverageHashrate(xmrWall);   
            if (Equals(hashrate.Data.H3, 0f))
            {
                Task.Factory.StartNew(() => _senderBot.SendMessage("xmr 0 выработки"));
                Console.WriteLine("xmr 0 выработки");
            }
        }
    }
}
