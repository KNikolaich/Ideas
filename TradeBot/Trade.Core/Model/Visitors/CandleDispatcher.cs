using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Visitor;

namespace Trader.Model.Visitors
{
    /// <summary> Диспетчер посетителей для свечей </summary>
    internal class CandleDispatcher : Dispatcher<Candle>
    {
        /// <summary> Диспетчер посетителей для свечей </summary>
        public CandleDispatcher()
        {
            Add(new CandleSimpleMovingAverageCalcVisitor());
            Add(new CandleRsiCalcVisitor());
            Add(new CandleMacDCalcVisitor());
            Add(new CandleStochRsiVisitor());
        }
    }
}
