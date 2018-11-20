using System.Collections.Generic;

namespace Trader.Ancillary
{
    public struct MacDStruct
    {
        private Dictionary<short, decimal> _ema;

        /// <summary>
        /// Наша дельта, это и есть осцилограмма
        /// </summary>
        public decimal Hystogram { get; set; }

        /// <summary>
        /// Это SMA по осцилограмме
        /// </summary>
        public decimal Signal { get; set; }
        
        ///// <summary>
        ///// Разница между Гистрограммной и Сигнальной линиями //  смена именно этой полярности должна быть сигналом к действию
        ///// </summary>
        //public decimal HystoMinusSignal => Hystogram - Signal;

        /// <summary>
        /// Словарчик с экспоненциальными
        /// </summary>
        public Dictionary<short, decimal> Ema
        {
            get { return _ema ?? (_ema = new Dictionary<short, decimal>()); }
            set { _ema = value; }
        }

        /// <summary>
        /// пересчет сигнальной линии
        /// </summary>
        /// <param name="candle">текущая свеча</param>
        /// <param name="period">период (глубина)</param>
        public void CalcSignal(Candle candle, short period)
        {
            var summ = 0m;
            var currCundle = candle;
            int i;
            for (i = 0; i < period; i++)
            {
                summ += currCundle.MacD.Hystogram;
                currCundle = currCundle.PreviousCandle;
                if (currCundle == null)
                {
                    //AddMessage($"для расчета SMO({movingAverage.Depth}) недостаточно свечей!");
                    break;
                }
            }
            Signal = summ / (i+1);
        }
        
        public override string ToString()
        {
            return $"Hystogram: {Hystogram:G7}, Signal:{Signal:G7}";
        }

    }
}