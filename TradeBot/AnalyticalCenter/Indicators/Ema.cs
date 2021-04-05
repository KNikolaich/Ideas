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
        public Ema(int depth) : base(depth)
        {
        }

        public override decimal CalcThis(decimal price, IIndicator preview)
        {
            base.CalcThis(price, preview);
            var p = P();
            Value = (price * p) + (preview != null ? (preview.Value * (1 - p)) : 0);
            return Value;
        }

        private decimal P()
        {
            return (2m ) / (Depth + 1);
        }

    }
}
