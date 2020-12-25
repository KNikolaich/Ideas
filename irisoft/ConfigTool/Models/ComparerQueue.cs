using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration.Models
{
    public  static class QueueExtender
    {
        public static int CompareWith(this int xQueue, int yQueue)
        {
            if (xQueue < 0)
                return int.MaxValue;
            if (yQueue < 0)
                return int.MinValue;
            var queueComparison = xQueue.CompareTo(yQueue);
            return queueComparison;
        }
    }
}
