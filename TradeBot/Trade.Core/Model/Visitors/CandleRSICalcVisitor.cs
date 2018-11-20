using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Ancillary;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader.Model.Visitors
{
    /// <summary>
    /// Калькулятор показателя RSI
    /// </summary>
    /// <remarks>
    /// Так, для того, чтобы рассчитать RSI с периодом 14, надо сделать следующее:
    /// Отметить цену закрытия последних 14 баров(свечей).
    /// Выделить бары, когда рынок закрывался выше, чем предыдущий бар.
    /// Суммировать все повышения цен и разделить их на 14 (кол-во периодов). В результате получим среднее повышение цен закрытия за X-периодов.
    /// Выделить бары, когда рынок закрывался ниже, чем предыдущий бар.
    /// Суммировать все понижения цен и разделить их на 14. В результате получим среднее понижение цен закрытия за X-периодов.
    /// Рассчитать RS — относительную силу по приведенной выше формуле.Для этого разделим среднее значение повышения цен на среднее значения понижения цен.
    /// Рассчитать индекс относительной силы RSI.
    /// Повторить расчет после закрытия следующего бара.
    /// </remarks>
    internal class CandleRsiCalcVisitor : VisitorBase<Candle>
    {
        public CandleRsiCalcVisitor()
        {
            NeedAccept = true;
        }

        internal override void Accept(Candle candle)
        {

            var nsiRsi = OrmDataHelper.GetCollection<Nsi_Rsi>("Active = 1")?.FirstOrDefault();
            if (nsiRsi != null && candle.CanBeDeeper(nsiRsi.Depth))
            {
                var rsiValue = GetRsiValue(candle, nsiRsi.Depth, nsiRsi.SmaTrendLine);
                BalancePair.SaveBalance(new BalancePair.CurrencyVolume("RSI", rsiValue, candle.StartDate, candle.ClosePrice));

                candle.RsiValue = rsiValue;

                //CreatePredictions(candle, nsiRsi);
            }

            NeedAccept = false;
        }
        
        /// <summary>
        /// Рассчет показателя RSI 
        /// </summary>
        /// <param name="candle"></param>
        /// <param name="nsiRsiDepth"></param>
        /// <param name="trendLine"></param>
        /// <returns></returns>
        internal static short GetRsiValue(Candle candle, short nsiRsiDepth, short trendLine)
        {
            var currCandle = candle;
            short rsiValue = 0;
            decimal topLevelSumm = 0; // сумма повышений цен закрытия
            decimal btmLevelSumm = 0; // сумма понижений цен закрытия
            decimal nextPrice;
            for (short i = 0; i < nsiRsiDepth; i++)
            {
                nextPrice = currCandle.ClosePrice;
                currCandle = currCandle.PreviousCandle;
                if (currCandle != null)
                {
                    if (currCandle.ClosePrice < nextPrice)
                    {
                        topLevelSumm += nextPrice - currCandle.ClosePrice;
                    }
                    else if (currCandle.ClosePrice > nextPrice)
                    {
                        btmLevelSumm += currCandle.ClosePrice - nextPrice;
                    }
                }
            }

            if (btmLevelSumm == 0) // делить на 0 нельзя, ставим максимальное значение RSI 
            {
                rsiValue = 100;
            }
            else
            {
                var rs = (topLevelSumm / nsiRsiDepth) / (btmLevelSumm / nsiRsiDepth);
                rsiValue = (short) (100 - 100 / (1 + rs));
            }

            if (trendLine > 0 && candle.CanBeDeeper(trendLine))
            {
                var smaTrand = candle.Sma(trendLine);
                BalancePair.SaveBalance(new BalancePair.CurrencyVolume("RSI_trand", smaTrand, candle.StartDate,
                    candle.ClosePrice));
            }

            return rsiValue;
        }

        private void CreatePredictions(Candle candle, Nsi_Rsi rsi)
        {
            // Смотрим , есть ли просчет тренда на данную свечу и предыдущую
            decimal? currSma = candle.GetSma(rsi.SmaTrendLine);
            decimal? prevSma = candle.PreviousCandle?.GetSma(rsi.SmaTrendLine);
            if (currSma.HasValue && prevSma.HasValue)
            {
                StyleCandleEnum trendEnum = StyleCandleEnum.Dogi;
                if (prevSma > currSma)
                {
                    trendEnum = StyleCandleEnum.Bear;
                }
                else if (prevSma < currSma)
                {
                    trendEnum = StyleCandleEnum.Bovine;
                }


                // медвежий тренд:
                // при выходе с зоны TopLevel продаем
                if (trendEnum == StyleCandleEnum.Bear)
                {
                    candle.CreatePrediction("покупай " + BalanceTailEnum.Rsi, candle.ClosePrice, "при выходе с зоны TopLevel продаем");
                    Messages.Add("Buy");

                    //candle.CreatePrediction("покупай " + BalanceTailEnum.MacD, candle.ClosePrice);

                    // при перевале ниже 50% - выкупаем обратно на тренд не глядя TODO самый простой варик, на самом деле, надо внимательней смотреть на откуп
                    if (candle.PreviousCandle.RsiValue > 50 && candle.RsiValue <= 50)
                    {
                        candle.CreatePrediction("продавай " + BalanceTailEnum.Rsi, candle.ClosePrice, "при перевале ниже 50% - выкупаем обратно");
                        Messages.Add("Sell");
                    }
                }

                // бычий тренд:
                // при выходе с зоны buttomLevel закупаем
                if (trendEnum == StyleCandleEnum.Bovine)
                {
                    candle.CreatePrediction("покупай " + BalanceTailEnum.Rsi, candle.ClosePrice, "при выходе с зоны buttomLevel закупаем");
                    Messages.Add("Buy");

                    //candle.CreatePrediction("продавай " + BalanceTailEnum.Rsi, candle.ClosePrice);

                    // при перевале через 50% - продаем TODO самый простой варик, на самом деле, надо внимательней смотреть на откуп
                    if (candle.PreviousCandle.RsiValue > 50 && candle.RsiValue <= 50)
                    {
                        candle.CreatePrediction("продавай " + BalanceTailEnum.Rsi, candle.ClosePrice, "при перевале через 50% - продаем ");
                        Messages.Add("Sell");
                    }
                }
            }

        }
    }
}
