using Binance.API.Csharp.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticalCenter.Helpers
{
    public class ParametersForTestStrategy
    {
        public DateTime start { get; set; }

        public DateTime? end { get; set; }
        
        public string pair { get; set; }
        
        public TimeInterval period { get; set; }

        public decimal FirstVolume { get; set; }

        public decimal SecondVolume { get; set; }
    }

}
