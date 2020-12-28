using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Indicators
{
    /// <summary>
    /// Экспоненциальная скользяцая средняя
    /// </summary>
    public class Ema : MovingAverage
    {
        public Ema(short depth) : base(depth)
        {
        }

        public void CalcValue(decimal price, decimal previewEmaValue = 0m)
        {
            var p = P();
            Value = (price * p) + (previewEmaValue * (1 - p));
        }
        internal void CalcValue(decimal lastPrice, decimal? value)
        {
            CalcValue(lastPrice, value ?? 0);
        }

        private decimal P()
        {
            return (2m ) / (Depth + 1);
        }

    }
}
