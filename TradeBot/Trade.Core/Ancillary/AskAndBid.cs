using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Ancillary
{
    public class AskAndBid
    {
        public decimal? MaxAsk { set; get; }
        public decimal? MinBid { set; get; }
        public string StringView { get; set; }
        public decimal? MinAsk { get; set; }
        public decimal? MaxBid { get; set; }
    }
}
