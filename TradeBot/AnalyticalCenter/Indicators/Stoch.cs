using AnalyticalCenter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Indicators
{
    public class Stoch : IIndicator
    {
        private decimal _k;
        private decimal _price;
        private Stoch _previewStoch;
        private decimal _min;
        private decimal _max;
        private decimal _d;
        private readonly int DepthSmaK = 3; // обычно D смазывают на это значение глубины от k

        public Stoch()
        {
        }

        /// <summary>        Глубина проработки        /// </summary>
        public int Depth { get; private set; }

        public decimal Value => _k;

        public IIndicator PreviewIndicator => _previewStoch;

        public void SetPrices(decimal minPrice, decimal maxPrice)
        {
            _min = minPrice;
            _max = maxPrice;
        }

        public decimal CalcThis(decimal price, IIndicator preview)
        {
            _price = price;
            _previewStoch = (Stoch)preview;
            var extremumsByDepth = GetExtremums();
            if (extremumsByDepth.Item2 - extremumsByDepth.Item1 != 0) // а такое возможно в начале цепочки
                _k = 100 * (price - extremumsByDepth.Item1) / (extremumsByDepth.Item2 - extremumsByDepth.Item1);
            else
                _k = 50; // условное число. его в расчете стратегии брать нельзя, и следующие не глубину Depth тоже

            _d = new Sma(DepthSmaK).CalcThis(price, preview);

            return Value;
        }

        private (decimal, decimal) GetExtremums()
        {
            var min = decimal.MaxValue;
            var max = decimal.MinValue;
            var prevCalc = _previewStoch;
            for (short i = 0; i < Depth; i++)
            {
                if (prevCalc == null)
                    break;
                max = Math.Max(_max, prevCalc._max);
                min = Math.Min(_min, prevCalc._min);
                prevCalc = (Stoch)prevCalc.PreviewIndicator;
            }
            if(_previewStoch == null) // начало цепочки
            {
                return (_price, _price);
            }
            return (min, max);
        }

        public EnumOrderDirect Validate()
        {
            throw new NotImplementedException();
        }
    }
}
