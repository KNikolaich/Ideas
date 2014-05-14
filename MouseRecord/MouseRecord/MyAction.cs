using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MouseRecord
{
    class MyAction
    {
        public MyAction(TimeSpan timeSpan, Point point)
        {
            TimeSpan = timeSpan;
            Point = point;
        }

        public TimeSpan TimeSpan { get; set; }
        public Point Point { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return String.Format("Клик в {0} через {1}сек.", Point, TimeSpan.TotalSeconds);
        }

        #endregion
    }
}
