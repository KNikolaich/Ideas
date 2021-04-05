using AnalyticalCenter.Helpers;
using AnalyticalCenter.Indicators;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegaBot;

namespace AnalyticalCenter.Strategy
{
    public abstract class BaseStrategy : IStrategy
    {
        Queue<EnumOrderDirect> orderQueue = new Queue<EnumOrderDirect>();
        protected Speaker _speaker = Speaker.Instance();
        static bool _willBeStop;

        // взять свечи за период
        // начиная с последней вычисляем MacD
        // берем его, запихиваем вместе с новым значением цены закрытия и вычисляем новое значение macD
        internal ParametersForTestStrategy _parameters;


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

        protected void Start(Subscriber subscriber)
        {
            // стартуем генерацию стратегии на выбранный диапазон , с выбранной парой
            // при генерации, делаем паузы , соотвествующие нашим запросам, и продолжаем генерировать, валидировать и ждем отмену
            _willBeStop = false;
            Task.Factory.StartNew(() => StartStrategyAsync(subscriber));
        }

        private async void StartStrategyAsync(Subscriber param)
        {
            List<IIndicator> result = new List<IIndicator>();
            _parameters = new ParametersForTestStrategy()
            {
                pair = param.Pair,
                FirstVolume = 1
            };
            try
            {
                IEnumerable<Candlestick> stiksCandle = GenerateCandlesAsync(param);
                IIndicator prevIndicator = null;
                foreach (var stick in stiksCandle)
                {
                    if (stick == null)
                    {
                        return;
                    }
                    ValidateQueue(stick);
                    prevIndicator = Create(stick, prevIndicator);
                    result.Add(prevIndicator);
                }
            }
            catch (Exception ex)
            {
                _speaker.CanBeInteresting(this, new MessageEventArg(ex.Message, SubscribeLevelEnum.Error));
            }
            finally
            {
                _willBeStop = false;
            }
        }

        internal IIndicator Create(Candlestick stick, IIndicator prevIndicator)
        {
            var validResult = EnumOrderDirect.Nothing;
            var newMacd = CreateIndicator(stick, prevIndicator);
            validResult = newMacd.Validate();
            if(validResult != EnumOrderDirect.Nothing)
            {
                OnEnqueue(validResult);
            }
            return newMacd;
        }

        protected abstract IIndicator CreateIndicator(Candlestick stick, IIndicator prevIndicator);

        internal void ValidateQueue(Binance.API.Csharp.Client.Models.Market.Candlestick stick)
        {
            var price = stick.Open;
            switch (Dequeue())
            {
                case EnumOrderDirect.Sale:
                    if (_parameters?.FirstVolume > 0)
                    { // покупаем на все деньги первой пары валюту второй
                        _parameters.SecondVolume = _parameters.FirstVolume * price;
                        _parameters.FirstVolume = 0;
                    }
                    OnCanBeInteresting($"{Converters.GeDateTime(stick.OpenTime).ToShortDateString()} Продано за {price:n4}, \t Стало {_parameters.SecondVolume:n4} второй валюты", TelegaBot.SubscribeLevelEnum.Warning);
                    break;

                case EnumOrderDirect.Buy:
                    if (_parameters?.SecondVolume > 0)
                    { // покупаем на все деньги первой пары валюту второй
                        _parameters.FirstVolume = _parameters.SecondVolume / price;
                        _parameters.SecondVolume = 0;
                    }
                    OnCanBeInteresting($"{Converters.GeDateTime(stick.OpenTime).ToShortDateString()} Куплено за {price:n4}, \t Стало {_parameters.FirstVolume:n4} первой валюты ", TelegaBot.SubscribeLevelEnum.Warning);
                    break;
            }
        }

        protected void Stop()
        {
            // останавливаем генерацию. 
            _willBeStop = true;
        }

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



        internal IEnumerable<Candlestick> GenerateCandlesAsync(Subscriber param)
        {
            DateTime start = GetStartDate(param.interval);


            var span = Converters.IntervalToTimespan(param.interval);
            do
            {
                Candlestick last = null;
                var end = DateTime.Now;
                var stickCandle = Burse.GetBinanceClient().GetCandleSticks(param.Pair, param.interval, start, end, 1000).Result;
                foreach (var stick in stickCandle)
                {
                    if (_willBeStop)
                        yield return null;

                    yield return stick;
                    last = stick;
                }

                var lastClose = last != null ? Converters.GeDateTime(last.CloseTime) : DateTime.Now;

                while (lastClose.AddMilliseconds(1) > DateTime.Now)
                {
                    if (_willBeStop)
                        yield return null;
                    Thread.Sleep(1000);
                }
                start = lastClose.AddMilliseconds(1);
            }
            while (true);
        }

        /// <summary>
        /// Высчитываем 200 итераций с начала данного момента
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        private DateTime GetStartDate(TimeInterval interval)
        {
            var span = Converters.IntervalToTimespan(interval);

            return DateTime.Today.AddSeconds(-(span.TotalSeconds * 600));
        }
    }

}
