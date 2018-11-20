using System;
using System.Runtime.Serialization;

namespace Trader.Model
{
    /// <summary> билет с рынка (какие уровни у пары валют на данный момент)  </summary>
    [DataContract]
    public class Ticker
    {
        /// <summary>
        /// Валюта (основная)
        /// </summary>
        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.cur' is never used
        private String cur;
#pragma warning restore CS0169 // The field 'Ticker.cur' is never used

        /// <summary>
        /// Валюта обмена
        /// </summary>
        [DataMember]
        private String symbol;

        /// <summary>
        /// последняя
        /// </summary>
        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.last' is never used
        private Double last;
#pragma warning restore CS0169 // The field 'Ticker.last' is never used

        /// <summary>
        /// высшая
        /// </summary>
        [DataMember]
#pragma warning disable CS0649 // Field 'Ticker.high' is never assigned to, and will always have its default value 0
        private Double high;
#pragma warning restore CS0649 // Field 'Ticker.high' is never assigned to, and will always have its default value 0

        /// <summary>
        /// нижняя
        /// </summary>
        [DataMember]
#pragma warning disable CS0649 // Field 'Ticker.low' is never assigned to, and will always have its default value 0
        private Double low;
#pragma warning restore CS0649 // Field 'Ticker.low' is never assigned to, and will always have its default value 0

        /// <summary>
        /// значение
        /// </summary>
        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.volume' is never used
        private Double volume;
#pragma warning restore CS0169 // The field 'Ticker.volume' is never used

        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.vwap' is never used
        private Double vwap;
#pragma warning restore CS0169 // The field 'Ticker.vwap' is never used

        [DataMember]
        private Double max_bid;

        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.best_bid' is never used
        private Double best_bid;
#pragma warning restore CS0169 // The field 'Ticker.best_bid' is never used

        [DataMember]
#pragma warning disable CS0169 // The field 'Ticker.best_ask' is never used
        private Double best_ask;
#pragma warning restore CS0169 // The field 'Ticker.best_ask' is never used

        [DataMember]
        private Double min_ask;

        public String getSymbol()
        {
            return symbol;
        }

        public void setSymbol(String symbol)
        {
            this.symbol = symbol;
        }

        public Double getMaxBid()
        {
            return max_bid;
        }

        public void setMaxBid(Double maxBid)
        {
            this.max_bid = maxBid;
        }

        public Double getMinAsk()
        {
            return min_ask;
        }

        public void setMinAsk(Double minAsk)
        {
            this.min_ask = minAsk;
        }

        public override string ToString()
        {
            return $"{symbol}: low({low}) high({high})";
        }
    }
}
