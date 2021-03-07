using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BotCore;
using Microsoft.Extensions.Configuration;
using PoolsSelector;

namespace ConsoleBotMiners
{
    /// <summary>
    /// Монитор майнеров
    /// </summary>
    class MinersMonitor
    {
        private Sender _senderBot;
        
        private IConfigurationRoot _conf;

        private DateTime _lasTime = DateTime.Now;

        public MinersMonitor()
        {
            _senderBot = new Sender();
            Command.CommandEventHandler += (sender, arg) =>
            {
                if (arg.Commands == CommandsEnum.Info) GetInfoAboutMiners(true);
            };
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

            Task.Factory.StartNew(() => _senderBot.ReadChatsAsync());
            if (_lasTime.AddMinutes(30) < DateTime.Now) // проверка осуществляется не чаще чем раз  впол часа
            {
                _lasTime = DateTime.Now;

                GetInfoAboutMiners();
            }
            //Task.Factory.StartNew(() => _senderBot.SendMessage("всем подписавшимся"));
        }

        private void GetInfoAboutMiners(bool mandatoryRespond = false)
        {
            var configuration = GetConfiguration();
            string value = "";
            
            var wallets = configuration.GetSection("Wallets");
            foreach (var wallet in wallets.GetChildren())
            {
                try
                {
                    PoolApiBase poolApiBase = null;
                    switch (wallet.Key)
                    {
                        case "Xmr":
                            poolApiBase = new Nanopool(NanopoolStatics.PoolType.XMR, wallet.Value);

                            break;
                        case "Eth":
                            poolApiBase = new Ethermine(wallet.Value);
                            break;
                    }

                    if (poolApiBase != null)
                    {
                        var hashrate = poolApiBase.GetCurrentHashrate();
                        if (Equals(hashrate, 0f) || mandatoryRespond)
                        {
                            var zeroStr = $"{wallet.Key} {hashrate:N} выработки";
                            value += !string.IsNullOrEmpty(value) ? Environment.NewLine + zeroStr : zeroStr;
                        }
                        if (mandatoryRespond)
                        {
                            var balance = poolApiBase.GetAccountBalance();
                            var zeroStr = $"баланс: {balance:N6} {wallet.Key}";
                            value += !string.IsNullOrEmpty(value) ? Environment.NewLine + zeroStr : zeroStr;
                        }
                    }
                }
                catch (Exception ex)
                {
                    value += Environment.NewLine + ex.Message;
                }
            }

            if (!string.IsNullOrEmpty(value))
            {
                Task.Factory.StartNew(() => _senderBot.SendMessage(value));
                Console.WriteLine(value);
            }
            /*var xmrWall = configuration["Wallets:xmr"];
            
            

            try
            {
                var ethWall = configuration["Wallets:eth"];

                // вызываем метод, передаем ему значения для параметров и получаем результат
                Ethermine ethMine = new Ethermine(ethWall);
                
                var ethHashrate = ethMine.GetCurrentHashrate();
                if (Equals(ethHashrate, 0f) || mandatoryRespond)
                {
                    
                }
            }
            catch(Exception ex)
            {
                value += Environment.NewLine + ex.Message;
            }
            */

        }
    }
}
