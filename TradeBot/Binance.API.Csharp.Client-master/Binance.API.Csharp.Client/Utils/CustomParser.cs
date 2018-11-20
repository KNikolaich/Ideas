using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.WebSocket;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Binance.API.Csharp.Client.Utils
{
    /// <summary>
    /// Class to parse some specific entities.
    /// </summary>
    public class CustomParser
    {
        /// <summary>
        /// Gets the orderbook data and generates an OrderBook object.
        /// </summary>
        /// <param name="orderBookData">Dynamic containing the orderbook data.</param>
        /// <returns></returns>
        public OrderBook GetParsedOrderBook(dynamic orderBookData)
        {
            var result = new OrderBook
            {
                LastUpdateId = orderBookData.lastUpdateId.Value
            };

            var bids = new List<OrderBookOffer>();
            var asks = new List<OrderBookOffer>();

            foreach (JToken item in ((JArray)orderBookData.bids).ToArray())
            {
                bids.Add(new OrderBookOffer() { Price = ParseDecimal(item[0]), Quantity = ParseDecimal(item[1]) });
            }

            foreach (JToken item in ((JArray)orderBookData.asks).ToArray())
            {
                asks.Add(new OrderBookOffer() { Price = ParseDecimal(item[0]), Quantity = ParseDecimal(item[1]) });
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }

        /// <summary>
        /// Gets the candlestick data and generates an Candlestick object.
        /// </summary>
        /// <param name="candlestickData">Dynamic containing the candlestick data.</param>
        /// <returns></returns>
        public IEnumerable<Candlestick> GetParsedCandlestick(dynamic candlestickData)
        {
            var result = new List<Candlestick>();
            //var jsonRes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Candlestick>>(candlestickData.ToString());
            foreach (JToken item in ((JArray)candlestickData).ToArray())
            {
                result.Add(new Candlestick()
                {
                    OpenTime = long.Parse(item[0].ToString()),
                    Open = ParseDecimal(item[1]),//System.Globalization.NumberStyles.AllowCurrencySymbol) 
                    High = ParseDecimal(item[2]),
                    Low = ParseDecimal(item[3]),
                    Close = ParseDecimal(item[4]),
                    Volume = ParseDecimal(item[5]),
                    CloseTime = long.Parse(item[6].ToString()),
                    QuoteAssetVolume = ParseDecimal(item[7]),
                    NumberOfTrades = int.Parse(item[8].ToString()),
                    TakerBuyBaseAssetVolume = ParseDecimal(item[9]),
                    TakerBuyQuoteAssetVolume = ParseDecimal(item[10])
                });
            }

            return result;
        }

        private static decimal ParseDecimal(JToken item)
        {
            decimal dRes;
            return decimal.TryParse(item.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint, new System.Globalization.CultureInfo("en-US"),out dRes) ? dRes: 0;
        }

        public DepthMessage GetParsedDepthMessage(dynamic messageData)
        {
            var result = new DepthMessage
            {
                EventType = messageData.e,
                EventTime = messageData.E,
                Symbol = messageData.s,
                UpdateId = messageData.u
            };

            var bids = new List<OrderBookOffer>();
            var asks = new List<OrderBookOffer>();

            foreach (JToken item in ((JArray)messageData.b).ToArray())
            {
                bids.Add(new OrderBookOffer() { Price = ParseDecimal(item[0]), Quantity = ParseDecimal(item[1])});
            }

            foreach (JToken item in ((JArray)messageData.a).ToArray())
            {
                asks.Add(new OrderBookOffer() { Price = ParseDecimal(item[0]), Quantity = ParseDecimal(item[1])});
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }
    }
}
