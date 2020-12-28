using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Indicators
{
    /// <summary>
    /// Скользаящая средняя
    /// </summary>
    public class MovingAverage
    {

        public MovingAverage(short depth)
        {
            Depth = depth;
        }


        /// <summary>
        /// Вычисленное уже значение
        /// </summary>
        public decimal Value { get; internal set; }

        [System.ComponentModel.Description(@"Глубина скольжения")]
        public short Depth
        {
            get;
            set;
        }
    }
}
