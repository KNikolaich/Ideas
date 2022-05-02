﻿using System;
using System.IO;
using System.Threading.Tasks;
using BotCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PoolsSelector;
using PoolsSelector.Data;

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
            foreach (var walletJson in wallets.GetChildren())
            {
                PoolApiBase poolApiBase = null;
                var wallet = JsonConvert.DeserializeObject<Wallet>(walletJson.Value);
                if (wallet != null)
                {
                    switch (walletJson.Key)
                    {
                        case "Xmr":
                            poolApiBase = new Nanopool(NanopoolStatics.PoolType.XMR, wallet.Id);

                            break;
                        case "Eth":

                            //poolApiBase = new Nanopool(NanopoolStatics.PoolType.ETH, wallet.Value);
                            poolApiBase = new Nanopool(NanopoolStatics.PoolType.ETH, wallet.Id);//Ethermine(wallet.Value);
                            break;
                    }

                }
                
                if (poolApiBase != null)
                {
                    try
                    {
                        //var hashrate = poolApiBase.GetCurrentHashrate();
                        var hashrate = poolApiBase.GetAverageHashrate(DurationTimeEnum.h1);
                        if (Equals(hashrate, 0f) || mandatoryRespond)
                        {

                            var zeroStr = $"{walletJson.Key} {hashrate:N} выработки";
                            value += !string.IsNullOrEmpty(value) ? Environment.NewLine + zeroStr : zeroStr;

                        }
                        if (mandatoryRespond)
                        {
                            var balance = poolApiBase.GetAccountBalance();
                            var zeroStr = $"баланс: {balance:N6} {walletJson.Key}";
                            value += !string.IsNullOrEmpty(value) ? Environment.NewLine + zeroStr : zeroStr;
                            var hashrate24 = poolApiBase.GetAverageHashrate(DurationTimeEnum.h24);
                            if (Equals(hashrate24, 0f))
                            {
                                value += Environment.NewLine + ("такими темпами майнить будет бесконечно :(");
                            }
                            else
                            {
                                var days = (wallet.Limit - balance) /(hashrate24 / 86400); // Делим хэшрейт на кол-во секунд в сутках
                                value += Environment.NewLine + ($"Планируемое дата окончания: {(DateTime.Now + TimeSpan.FromDays(days)).ToShortDateString()}");
                                
                            }
                            value += Environment.NewLine + "___________________________________________________";
                        }
                    }
                    catch (Exception ex)
                    {
                        value += $"{walletJson.Key} {0:N} выработки";

                        Task.Factory.StartNew(() => _senderBot.SendMessage(ex.Message, SubscribeLevelEnum.Error));
                    }
                }
            }

            if (!string.IsNullOrEmpty(value))
            {
                Task.Factory.StartNew(() => _senderBot.SendMessage(value));
                Console.WriteLine(value);
            }

        }
    }
}
