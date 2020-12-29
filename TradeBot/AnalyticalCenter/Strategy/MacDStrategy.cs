using AnalyticalCenter.Helpers;
using AnalyticalCenter.Indicators;
using Binance.API.Csharp.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCenter.Strategy
{
    public class MacDStrategy : BaseStrategy
    {
        // взять свечи за период
        // начиная с последней вычисляем MacD
        // берем его, запихиваем вместе с новым значением цены закрытия и вычисляем новое значение macD

        TimeInterval _period;

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
        public async Task<List<MacD>> TestForPeriodAsync(DateTime start, DateTime end, TimeInterval period)
        {
            List<MacD> result = new List<MacD>();

            try
            {
                _period = period;
                var stiksCandle = await Burse.GetBinanceClient().GetCandleSticks("EthUsdt", _period, start, end);
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
            switch (Dequeue())
            {
                case EnumOrderDirect.Buy:
                    OnCanBeInteresting($"Куплено за {stick.Open}");
                    break;

                case EnumOrderDirect.Sale:
                    OnCanBeInteresting($"Продано за {stick.Open}");
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
                    OnCanBeInteresting("Рекомендация: покупать.", newMacd);
                    OnEnqueue(EnumOrderDirect.Buy);
                }
                if (prevMacD.Difference >= 0 && newMacd.Difference < 0)
                {
                    OnCanBeInteresting("Рекомендация: продавать.", newMacd);
                    OnEnqueue(EnumOrderDirect.Sale);
                }
            }

            return newMacd;
        }

    }
}
