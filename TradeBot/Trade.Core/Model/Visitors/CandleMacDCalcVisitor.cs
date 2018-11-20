using System.Linq;
using DevExpress.Utils.Filtering.Internal;
using Trader.Ancillary;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader.Model.Visitors
{
    /// <summary>
    /// Тут мы должны построить по возможности MacD
    /// Если будут предсказания, - добавить их
    /// </summary>
    internal class CandleMacDCalcVisitor : VisitorBase<Candle>
    {
        public CandleMacDCalcVisitor()
        {
            NeedAccept = false;
        }

        internal override void Accept(Candle candle)
        {
            var nsiMacDs = OrmDataHelper.GetCollection<Nsi_MacD>("Active = 1");
            Nsi_MacD nsiMacD = nsiMacDs?.FirstOrDefault();
            if (nsiMacD != null)
            {
                /* Строим EMA на длину nsiMacD.ExpPeriodShort
                     * Строим EMA на длину nsiMacD.ExpPeriodLong
                     * находим их дельту , записываем в струтуру 
                     * находим SMA от этой дельты на длину nsiMacD.SignalPeriod
                     * эта SMA тоже то положительная , то отрицательная, 
                     * при пересечении SMA нуля, выясняем расходится ли с трендом или нет, если нет, покупаем
                     * на продажу смотрим расхождение, если оно есть, то открываем вторую длинную позицию после продажи короткой
                     */
                //var candleMacD = candle.MacD;
                var candleMacD = candle.MacD;
                var periodLong = nsiMacD.ExpPeriodLong;
                var emaLongVolume = candle.Ema(periodLong);
                candleMacD.Ema.Add(periodLong, emaLongVolume);

                var periodShort = nsiMacD.ExpPeriodShort;
                var emaLongShort = candle.Ema(periodShort);

                candleMacD.Ema.Add(periodShort, emaLongShort);
                candleMacD.Hystogram = emaLongShort - emaLongVolume;
                candleMacD.CalcSignal(candle, nsiMacD.SignalPeriod);
                candle.MacD = candleMacD;
//#if DEBUG
                //if (FiltredBuy(candle))
                {
                    BalancePair.SaveBalance(new BalancePair.CurrencyVolume("Hystogram", candleMacD.Hystogram, candle.StartDate, candle.ClosePrice));
                    BalancePair.SaveBalance(new BalancePair.CurrencyVolume("Signal", candleMacD.Signal, candle.StartDate, candle.ClosePrice));
                }
//#endif
                CreatePrediction(candle);
            }


            NeedAccept = false;
        }

        /// <summary>
        /// здесь мы фильтруем, создавать , не создавать рекомендацию на покупку, продажу
        /// </summary>
        /// <param name="candle"></param>
        private void CreatePrediction(Candle candle)
        {
            // рассматриваем отношения скользящих
            string message = null;

            if (candle.PreviousCandle == null || candle.PreviousCandle.MacD.Hystogram == 0)
            {
                message = "Последняя свеча в цепи или для какой то из средних предыдещей свечи невозможно расчитать значение!";
            }
            else
            {
                var currMacd = candle.MacD;
                var prevMacd = candle.PreviousCandle.MacD;
                if (currMacd.Hystogram > 0 && prevMacd.Hystogram < 0 && FiltredBuy(candle))
                {
                    candle.CreatePrediction("покупай " + BalanceTailEnum.MacD, candle.ClosePrice, "Пересечение гистрограммы MacD нуля");
                    message = "buy";
                }
                else if (currMacd.Hystogram < 0 && prevMacd.Hystogram > 0)
                {
                    candle.CreatePrediction("продавай " + BalanceTailEnum.MacD, candle.ClosePrice, "Пересечение гистрограммы MacD нуля");
                    message = "sell";
                }
            }

            if (!string.IsNullOrEmpty(message))
            {
                AddMessage(message);
            }

        }

        /// <summary>
        /// Фильтрация при покупке
        /// </summary>
        /// <param name="candle"></param>
        /// <returns></returns>
        private static bool FiltredBuy(Candle candle)
        {
            // проверяем глубину свечей, чтобы не формировать не нужных сигналов
            //var depthCandle = candle;
            //var depth = Properties.Settings.Default.DepthQueue - 5;
            //for (int i = 0; i < depth; i++)
            //{
            //    depthCandle = depthCandle.PreviousCandle;
            //    if (depthCandle == null)
            //    {
            //        return false;
            //    }
            //}
            return true;//candle.MacD.Hystogram < 0;
        }

    }
}
