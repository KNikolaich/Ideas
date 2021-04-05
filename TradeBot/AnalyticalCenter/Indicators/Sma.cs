using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyticalCenter.Indicators
{

    /// <summary>
    /// Простая скользяцая средняя
    /// </summary>
    public class Sma : MovingAverage
    {

        List<decimal> _listPrices = new List<decimal>();

        public Sma(int depth) : base(depth)
        {
        }

        public override decimal CalcThis(decimal price, IIndicator preview)
        {
            base.CalcThis(price, preview);
            // сохраняем список на доступную глубину из предыдущих значений
            var prevCalc = preview.PreviewIndicator;
            for (short i = 0; i < Depth; i++)
            {
                if (prevCalc == null)
                    break;
                _listPrices.Add(prevCalc.Value);
                prevCalc = prevCalc.PreviewIndicator;
            }

            // если список не пуст , находим среднее арифметическое из значений
            if (_listPrices.Count == 0)
            {
                Value = preview.Value;
            }
            else
            {
                Value = _listPrices.Sum() / _listPrices.Count;

            }
            return Value;
        }

    }
}
