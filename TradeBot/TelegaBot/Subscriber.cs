using System;
using System.Collections.Generic;
using Binance.API.Csharp.Client.Utils;
using Binance.API.Csharp.Client.Models.Enums;

namespace TelegaBot
{
    public class Subscriber
    {
        public Subscriber()
        {
            Level = SubscribeLevelEnum.Info;
            Pair = "EthUsdt";
            interval = TimeInterval.Days_3;
        }

        public long ChatId { get; set; }

        public SubscribeLevelEnum Level { get; set; }

        public string  Pair { get; set; }

        public TimeInterval interval { get; set; }

        public override string ToString()
        {
            return $"Установки для подписчика: Уровень информации - {Level}; пара - {Pair}; на интервал - {interval.GetDescription()}";
        }
    }
}
