using System;

namespace Trader.Ancillary
{
    public class ProgressInfo : EventArgs
    {
        public ProgressInfo(int currentValue = 0, int maximumValue = 100, string comment = "")
        {
            CurrentValue = currentValue;
            MaximumValue = maximumValue;
            Comment = comment;
        }

        public int CurrentValue { get; }

        public int MaximumValue { get; }

        public string Comment { get; }
    }
}