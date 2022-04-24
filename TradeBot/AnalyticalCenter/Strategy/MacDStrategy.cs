using AnalyticalCenter.Helpers;
using AnalyticalCenter.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SaverToDb.Db;
using TelegaBot;
using Candlestick = Binance.API.Csharp.Client.Models.Market.Candlestick;

namespace AnalyticalCenter.Strategy
{
    public class MacDStrategy : BaseStrategy
    {
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
        public async Task<List<IIndicator>> TestForPeriodAsync(ParametersForTestStrategy param)
        {
            List<IIndicator> result = new List<IIndicator>();

            try
            {
                _parameters = param;
                var stiksCandle = await Burse.GetBinanceClient().GetCandleSticks(param.pair, param.period, param.start, param.end);
                IIndicator prevMacD = null;
                foreach (var stick in stiksCandle)
                {
                    ValidateQueue(stick);
                    prevMacD = Create(stick, prevMacD);
                    result.Add(prevMacD);
                }
            }
            catch(Exception ex)
            {
                _speaker.CanBeInteresting(this, new MessageEventArg(ex.Message, SubscribeLevelEnum.Error));
            }
            return result;
        }
        public List<IIndicator> TestFromDbForPeriod(ParametersForTestStrategy param)
        {
            List<IIndicator> result = new List<IIndicator>();

            try
            {
                _parameters = param;

                foreach (var stick in ModelBinance.GetCandleSticks(param.pair, param.period, param.start, param.end.Value))
                {
                    IIndicator prevMacD = null;
                    
                    prevMacD = Create(stick, prevMacD);

                    // Вот тут надо посмотреть внимательно, вместо той валидации, замутить проход до экстремума назад по превьюшкам.
                    // Данные валидации так же записывать в стик с экстремумом или предыдущий ему.
                    ValidateQueue(stick);
                    result.Add(prevMacD);
                    
                }
            }
            catch (Exception ex)
            {
                _speaker.CanBeInteresting(this, new MessageEventArg(ex.Message, SubscribeLevelEnum.Error));
            }
            return result;
        }

        protected override IIndicator CreateIndicator(Candlestick stick, IIndicator prevIndicator)
        {
            return MacD.Create(stick, prevIndicator);
        }
    }
}
