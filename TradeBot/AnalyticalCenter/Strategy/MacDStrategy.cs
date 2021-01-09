using AnalyticalCenter.Helpers;
using AnalyticalCenter.Indicators;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegaBot;

namespace AnalyticalCenter.Strategy
{
    public class MacDStrategy : BaseStrategy
    {
        // взять свечи за период
        // начиная с последней вычисляем MacD
        // берем его, запихиваем вместе с новым значением цены закрытия и вычисляем новое значение macD

        ParametersForTestStrategy _parameters;

        static bool _willBeStop;

        // для тестовых данных забираем периодс с ... по 
        // для режима реального времени забираем данные с периода 2х от максимума по средней MacD 2*26 периодов

        // из всех свечей нам интересно только цена открытия и цена закрытия (по последней строим график, по первой - торгуем)
        /// <summary>
        /// Тестирование
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<List<MacD>> TestForPeriodAsync(ParametersForTestStrategy param)
        {
            List<MacD> result = new List<MacD>();

            try
            {
                _parameters = param;
                var stiksCandle = await Burse.GetBinanceClient().GetCandleSticks(param.pair, param.period, param.start, param.end);
                MacD prevMacD = null;
                foreach (var stick in stiksCandle)
                {
                    ValidateQueue(stick);
                    prevMacD = Create(stick, prevMacD);
                    result.Add(prevMacD);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private void ValidateQueue(Binance.API.Csharp.Client.Models.Market.Candlestick stick)
        {
            var price = stick.Open;
            switch (Dequeue())
            {
                case EnumOrderDirect.Buy:
                    if(_parameters?.FirstVolume > 0) 
                    { // покупаем на все деньги первой пары валюту второй
                        _parameters.SecondVolume = _parameters.FirstVolume * price;
                        _parameters.FirstVolume = 0;
                    }
                    OnCanBeInteresting($"{Converters.GeDateTime(stick.OpenTime).ToShortDateString()} Куплено за {price}, \t Стало {_parameters.SecondVolume} второй валюты", TelegaBot.SubscribeLevelEnum.Warning);
                    break;

                case EnumOrderDirect.Sale:
                    if (_parameters?.SecondVolume > 0)
                    { // покупаем на все деньги первой пары валюту второй
                        _parameters.FirstVolume = _parameters.SecondVolume / price;
                        _parameters.SecondVolume = 0;
                    }
                    OnCanBeInteresting($"{Converters.GeDateTime(stick.OpenTime).ToShortDateString()} Продано за {price}, \t Стало {_parameters.FirstVolume} первой валюты ", TelegaBot.SubscribeLevelEnum.Warning);
                    break;
            }
        }

        private MacD Create(Binance.API.Csharp.Client.Models.Market.Candlestick stick, MacD prevMacD)
        {
            var newMacd = MacD.Create(stick, prevMacD);
            if (prevMacD != null)
            {
                if (prevMacD.Difference <= 0 && newMacd.Difference > 0)
                {
                    //OnCanBeInteresting("Рекомендация: покупать.", newMacd);

                    OnEnqueue(EnumOrderDirect.Buy);
                }
                if (prevMacD.Difference >= 0 && newMacd.Difference < 0)
                {
                    //OnCanBeInteresting("Рекомендация: продавать.", newMacd);
                    // при общем восходящем тренде - ходл (при этом надо стоп лосы уметь ставить)
                    OnEnqueue(EnumOrderDirect.Sale);
                }
            }

            return newMacd;
        }

        protected override void Stop()
        {
            //throw new NotImplementedException();
            // останавливаем генерацию. 
            _willBeStop = true;
        }

        protected override void Start(Subscriber subscriber)
        {
            //throw new NotImplementedException();
            // стартуем генерацию стратегии на выбранный диапазон , с выбранной парой
            // при генерации, делаем паузы , соотвествующие нашим запросам, и продолжаем генерировать, валидировать и ждем отмену
            _willBeStop = false;
            Task.Factory.StartNew(() => StartStrategyAsync(subscriber));
        }

        private async void StartStrategyAsync(Subscriber param)
        {
            List<MacD> result = new List<MacD>();
            _parameters = new ParametersForTestStrategy()
            {
                pair = param.Pair,
                FirstVolume = 1
            };
            try
            {
                IEnumerable<Candlestick> stiksCandle = GenerateCandlesAsync(param);
                MacD prevMacD = null;
                foreach (var stick in stiksCandle)
                {
                    if(stick == null)
                    {
                        return;
                    }
                    ValidateQueue(stick);
                    prevMacD = Create(stick, prevMacD);
                    result.Add(prevMacD);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                _willBeStop = false;
            }
        }

        private IEnumerable<Candlestick> GenerateCandlesAsync(Subscriber param)
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

                var lastClose = last != null ? Converters.GeDateTime(last.CloseTime): DateTime.Now;

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

            return DateTime.Today.AddSeconds(-(span.TotalSeconds * 20));
        }
    }
}
