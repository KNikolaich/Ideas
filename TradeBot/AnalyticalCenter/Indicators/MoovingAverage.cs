using AnalyticalCenter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Indicators
{
    /// <summary>
    /// Скользаящая средняя
    /// </summary>
    public abstract class MovingAverage : IIndicator
    {
        private IIndicator _previewMa;

        public MovingAverage(int depth)
        {
            Depth = depth;
        }


        /// <summary>
        /// Вычисленное уже значение
        /// </summary>
        public decimal Value { get; internal set; }

        [System.ComponentModel.Description(@"Глубина скольжения")]
        public int Depth
        {
            get;
            set;
        }

        public IIndicator PreviewIndicator => _previewMa;

        public virtual decimal CalcThis(decimal price, IIndicator preview)
        {
            _previewMa = preview;
            return price;
        }

        public EnumOrderDirect Validate()
        {
            throw new NotImplementedException();
        }
    }
}
