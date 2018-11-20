using System.Linq;
using Trader.Ancillary;
using Trader.LiveCoin;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader.Model.Visitors
{
    /// <summary>
    /// Калькулятор показателя Стохастический RSI
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal sealed class CandleStochRsiVisitor : VisitorBase<Candle>
    {
        public CandleStochRsiVisitor()
        {
            NeedAccept = true;
        }

        internal override void Accept(Candle candle)
        {

            var nsiStochRsi = OrmDataHelper.GetCollection<Nsi_StochRsi>("Active = 1")?.FirstOrDefault();
            if (nsiStochRsi != null && candle.CanBeDeeper(nsiStochRsi.RsiDepth))
            {

                var rsiValue = CandleRsiCalcVisitor.GetRsiValue(candle, nsiStochRsi.RsiDepth, 75);
                candle.Stoch = new StochAssistant {RsiValue = rsiValue};

                var sumDepth = nsiStochRsi.RsiDepth + nsiStochRsi.StochDepth;
                if (candle.CanBeDeeper((short)sumDepth))
                {
                    var currCandle = candle;
                    decimal lowestRsi = currCandle.Stoch.RsiValue;
                    decimal highestRsi = currCandle.Stoch.RsiValue;
                    for (short s = nsiStochRsi.StochDepth; s >= 0; s--)
                    {
                        if (currCandle.Stoch.RsiValue < lowestRsi)
                        {
                            lowestRsi = currCandle.Stoch.RsiValue;
                        }
                        if (currCandle.Stoch.RsiValue > highestRsi)
                        {
                            highestRsi = currCandle.Stoch.RsiValue;
                        }
                        currCandle = currCandle.PreviousCandle;
                    }

                    decimal key = 100 * (candle.Stoch.RsiValue - lowestRsi) / (highestRsi - lowestRsi);
                    candle.Stoch.Value = key;

                    decimal[] ints = new decimal[nsiStochRsi.MaPrima];

                    currCandle = candle;
                    for (short s = 0; s < nsiStochRsi.MaPrima; s++)
                    {
                        ints[s] = currCandle.Stoch.Value;

                        currCandle = currCandle.PreviousCandle;
                    }
                    candle.Stoch.KeyMaValue = SMAStruct.Calc(ints).Volume;

                    decimal[] ints2 = new decimal[nsiStochRsi.MaSecond];

                    currCandle = candle;
                    for (short s = 0; s < nsiStochRsi.MaSecond; s++)
                    {
                        ints2[s] = currCandle.Stoch.KeyMaValue;

                        currCandle = currCandle.PreviousCandle;
                    }
                    
                    candle.Stoch.DiMaValue = SMAStruct.Calc(ints2).Volume;

                    BalancePair.SaveBalance(new BalancePair.CurrencyVolume("StochRSI_K", candle.Stoch.KeyMaValue, candle.StartDate, candle.ClosePrice));
                    BalancePair.SaveBalance(new BalancePair.CurrencyVolume("StochRSI_D", candle.Stoch.DiMaValue, candle.StartDate, candle.ClosePrice));

                    CreatePredictions(candle);
                }
                BalancePair.SaveBalance(new BalancePair.CurrencyVolume("StochRSI", candle.Stoch.RsiValue, candle.StartDate, candle.ClosePrice));


            }

            NeedAccept = false;
        }

        private void CreatePredictions(Candle candle)
        {
            string interpretation = null;
            var actionStyle = StochAssistant.CalcPrediction(candle, ref interpretation);
            
            switch (actionStyle)
            {
                case StyleTickedEnum.BUY:
                    candle.CreatePrediction("покупай " + BalanceTailEnum.Rsi, candle.ClosePrice, interpretation);
                    Messages.Add("Buy");
                    break;
                case StyleTickedEnum.SELL:
                    candle.CreatePrediction("продавай " + BalanceTailEnum.Rsi, candle.ClosePrice, interpretation);
                    Messages.Add("Sell");
                    break;
                
            }
        }
    }
}
