﻿using AnalyticalCenter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Strategy
{
    public class BaseStrategy : IStrategy
    {
        Queue<EnumOrderDirect> orderQueue = new Queue<EnumOrderDirect>();
        Speaker _speaker = Speaker.Instance(); 

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
