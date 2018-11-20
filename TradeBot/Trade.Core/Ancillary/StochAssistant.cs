using DevExpress.Xpo;
using Trader.LiveCoin;

namespace Trader.Ancillary
{
    public class StochAssistant
    {

        /// <summary>
        /// Калькулируемое свойство для хранения индикатора Rsi для дальнейшего расчета по нему стохастика
        /// </summary>
        [NonPersistent]
        public decimal RsiValue { get; set; }

        /// <summary>
        /// Калькулируемое свойство для хранения чистого стохастического сигнала
        /// </summary>
        [NonPersistent]
        public decimal Value { get; set; }


        /// <summary>
        /// Калькулируемое свойство для хранения индикатора K% стохастика
        /// </summary>
        [NonPersistent]
        public decimal KeyMaValue { get; set; }

        /// <summary>
        /// Калькулируемое свойство для хранения индикатора D% стохастика
        /// </summary>
        [NonPersistent]
        public decimal DiMaValue { get; set; }

        /// <summary>
        /// Рассчет возможной необходимости дать совет
        /// </summary>
        /// <param name="candle"></param>
        /// <param name="interpretation"></param>
        /// <returns></returns>
        public static StyleTickedEnum CalcPrediction(Candle candle, ref string interpretation)
        {
            var prev = candle.PreviousCandle?.Stoch;
            if (prev != null)
            {
                interpretation = "пересечение привых";
                if (//candle.Stoch.KeyMaValue >= 90 && prev.KeyMaValue < 90 // выход за границу перекупленности - точно пора продавать! 
                    //|| //candle.Stoch.DiMaValue - candle.Stoch.KeyMaValue > 1 && // разница между кривыми больше 1 
                    prev.KeyMaValue >= prev.DiMaValue // раньше было K > D
                    && candle.Stoch.KeyMaValue <= candle.Stoch.DiMaValue) // стало K < D 
                {
                    if (prev.KeyMaValue <= prev.DiMaValue || candle.Stoch.KeyMaValue > candle.Stoch.DiMaValue)
                    {
                       // if (candle.Stoch.KeyMaValue >= 90 && prev.KeyMaValue < 90)
                        {
                        //    interpretation = "выход за границу 90";
                        }
                    }

                    //LogHolder.DebugLogInfo($"Продавать рекомендуется по причине {interpretation} \t цена {candle.ClosePrice}");
                    return StyleTickedEnum.SELL;
                }

                if (prev.KeyMaValue <= prev.DiMaValue // раньше было K < D
                    && candle.Stoch.KeyMaValue > candle.Stoch.DiMaValue // стало K > D 
                    //&& candle.Stoch.KeyMaValue - candle.Stoch.DiMaValue > 1 // разница между кривыми больше 1 
                    && candle.Stoch.KeyMaValue < 70
                    //|| candle.Stoch.KeyMaValue <= 10 && prev.KeyMaValue > 10 // либо вышли за границу перепроданности, значит пока покупать
                    )
                {
                    if (prev.KeyMaValue > prev.DiMaValue || candle.Stoch.KeyMaValue <= candle.Stoch.DiMaValue)
                    {
                        //if (candle.Stoch.KeyMaValue <= 10 && prev.KeyMaValue > 10)
                        //{
                         //   interpretation = "выход за границу 10";
                        //}
                    }

                    //LogHolder.DebugLogInfo($"Покупать рекомендуется по причине {interpretation} \t цена {candle.ClosePrice} ");
                    return StyleTickedEnum.BUY;
                }
            }
            return StyleTickedEnum.False;
        }
    }
}
