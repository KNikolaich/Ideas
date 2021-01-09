using AnalyticalCenter.Helpers;
using Binance.API.Csharp.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using TelegaBot;

namespace AnalyticalCenter.Strategy
{
    public abstract class BaseStrategy : IStrategy
    {
        Queue<EnumOrderDirect> orderQueue = new Queue<EnumOrderDirect>();
        Speaker _speaker = Speaker.Instance(); 

        public BaseStrategy()
        {
            _speaker.CommandEventHandler += _speaker_CommandEventHandler;
        }

        private void _speaker_CommandEventHandler(object sender, TelegaBot.CommandArg e)
        {
            switch (e.Commands)
            {
                case TelegaBot.CommandsEnum.Start:
                    Start(e.Subscriber);// из аргумента берем TimeInterval и валютную пару
                    break;

                case TelegaBot.CommandsEnum.Stop:
                    Stop();
                    break;
            }

        }

        protected abstract void Start(Subscriber subscriber);

        protected abstract void Stop();

        protected void OnCanBeInteresting(string msg, TelegaBot.SubscribeLevelEnum level, object reciept = null)
        {
            _speaker.OnCanBeInteresting(reciept ?? this, new MessageEventArg(msg, level));
        }

        protected void OnEnqueue(EnumOrderDirect direct)
        {
            orderQueue.Enqueue(direct);
        }
        protected EnumOrderDirect Dequeue()
        {
            var result = orderQueue.Count != 0 ? orderQueue.Dequeue() : EnumOrderDirect.Nothing;
            while (orderQueue.Count != 0 && orderQueue.Peek() != result)
            {
                orderQueue.Dequeue(); // пропускаем противомоложный сигнал сместе с этим
                result = orderQueue.Count != 0 ?  orderQueue.Dequeue() : EnumOrderDirect.Nothing;
            }
            return result;
        }
    }

}
