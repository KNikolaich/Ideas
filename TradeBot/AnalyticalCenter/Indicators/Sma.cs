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

        public Sma(short depth) : base(depth)
        {
        }

        internal void CalcByMacD(MacD macD)
        {
            var prevMacd = macD._previewMacD;
            for (short i = 0; i < Depth; i++)
            {
                if (prevMacd == null)
                    break;
                _listPrices.Add(prevMacd.Delta);
                prevMacd = prevMacd._previewMacD;
            }
            if(_listPrices.Count == 0)
            {
                Value = macD.Delta;
            }
            else
            {
                Value = _listPrices.Sum() / _listPrices.Count;

            }
        }
    }
}
