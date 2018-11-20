using Binance.API.Csharp.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Models.Account;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using Trader.LiveCoin;
using Trader.Model;
using Trader.Properties;

namespace Trader.Ancillary
{
    /// <summary>
    /// Биржа (менеджер, предназначенный для тонкого взаимодейсвия интерфейса с биржей)
    /// </summary>
    public static class Burse
    {
        public static BurseTypeEnum BurseType()
        {
            return (BurseTypeEnum)Enum.Parse(typeof(BurseTypeEnum), Settings.Default["BurseTypeEnum"].ToString());
        } 

        private static BinanceClient _binanceClient;
        private static Nsi_Exchange _exchangeCurrent;
        public static String CurrentName { get { return BurseType().ToString(); } }
        
        /// <summary>
        /// Текущая биржа, по настройкам БД
        /// </summary>
        public static Nsi_Exchange CurrentExchange => _exchangeCurrent ?? (_exchangeCurrent = Nsi_Exchange.GetCurrentExchange());


        /// <summary>
        /// Взять клиента бинанс биржи
        /// </summary>
        /// <returns></returns>
        public static BinanceClient GetBinanceClient()
        {
            if (_binanceClient == null)
            {
                NameValueCollection _appSettings = ConfigurationManager.AppSettings;
                
                string apiSecret;
                string apiKey;
                if (CurrentExchange != null || _appSettings["YourApiKey"] != null)
                {
                    if (CurrentExchange != null)
                    {
                        apiKey = CurrentExchange.ApiKey;
                        apiSecret = CurrentExchange.SecretKey;
                    }
                    else
                    {
                        apiKey = _appSettings["YourApiKey"];
                        apiSecret = _appSettings["YourApiSecret"];
                    }
                }
                else
                {
                    throw new NullReferenceException(
                        "Ни в БД. ни в конфиге не обозначены YourApiSecret для данной биржи");
                }
                ApiClient apiClient = new ApiClient(apiKey, apiSecret);
                _binanceClient = new BinanceClient(apiClient, false);
            }
            return _binanceClient;
        }

        /// <summary>
        /// Берем с текущей биржи все пары валют
        /// </summary>
        /// <returns></returns>
        internal static List<string> FindCurrencyPairList()
        {
            List<string> currencyPairList = new List<string>();
            switch (BurseType())
            {
                case BurseTypeEnum.LiveCoin:
                    var request = GetRequest.GetTicker<List<Ticker>>();
                    foreach (var symbol in request.Select(req => req.getSymbol()))
                    {
                        if (!currencyPairList.Contains(symbol))
                            currencyPairList.Add(symbol);
                    }
                    break;
                case BurseTypeEnum.BinanceCoin:
                    var results = GetBinanceClient().GetPriceChange24H().Result.ToArray();
                    foreach (var symbol in results.Select(res => res.Symbol))
                    {
                        if (!currencyPairList.Contains(symbol))
                            currencyPairList.Add(symbol);
                    }
                    break;
            }
            currencyPairList.Sort();
            return currencyPairList;
        }

        /// <summary>
        /// Взять время с сервера
        /// </summary>
        /// <returns></returns>
        public static async Task<DateTime?> GetServerTime()
        {
            var serverInfo = await GetBinanceClient().GetServerTime();
            if (serverInfo != null)
            {
                var serverTime = Converters.GeDateTime(serverInfo.ServerTime);
                return serverTime;
            }
            return null;
        }

        /// <summary>
        /// Получить полную инфу оп аккаунту
        /// </summary>
        /// <returns></returns>
        public static async Task<AccountInfo> GetAccountInfo()
        {
            return await GetBinanceClient().GetAccountInfo(1000L);
        }

        /// <summary>
        /// Получить полную инфу оп аккаунту
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Order>> GetAllOrders(string symbol, int limit = 50)
        {
            var orders = await GetBinanceClient().GetAllOrders(symbol, null, limit);
            foreach (var order in orders)
            {
                
                if (order.Price == 0)
                {
                    order.Price = await GetPriceForMarketOrder(order);
                }
            }
            return orders;
        }

        
        internal static async Task<decimal> GetPriceForMarketOrder(Order order)
        {
            decimal price = 0;
            var sticks = await GetBinanceClient().GetCandleSticks(order.Symbol, TimeInterval.Minutes_1, order.CalcTime, null, 1);
            var stick = sticks.FirstOrDefault();
            if (stick != null)
            {
                price = (stick.Low + stick.High) / 2; // берем среднюю, потому что не знаем как надо
            }

            return price;
        }

        /// <summary>
        /// Получить полную инфу по последним запросам
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<OrderBookOffer>> GetLastAsks(string symbol)
        {
            var orderBook = await GetBinanceClient().GetOrderBook(symbol, 10);
            return orderBook.Asks;
        }

        /// <summary>
        /// Получить полную инфу по последним предложениям
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<OrderBookOffer>> GetLastBids(string symbol)
        {
            var orderBook = await GetBinanceClient().GetOrderBook(symbol, 10);
            return orderBook.Bids;
        }

        public static async Task<NewOrder> PostNewOrder(string symbol, decimal volume, decimal price, OrderSide orderSide, OrderType market)
        {
            var order = await GetBinanceClient().PostNewOrder(symbol, volume, price, orderSide, market);
            return order;
        }

        /// <summary> Ордер был исполнен в лимитное время </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public static async Task<Order> OrderIsExecuteInLimitTime(NewOrder newOrder)
        {
            Order order = null;
            if (newOrder != null)
            {
                for (int i = 0; i < 10; i++) // выжидаем минуту
                {
                    order = await GetBinanceClient().GetOrder(newOrder.Symbol, newOrder.OrderId);
                    
                    if (order.Status == "FILLED" && order.ExecutedQty == order.OrigQty) // исполнено полностью
                    {
                        return order;
                    }

                    System.Threading.Thread.Sleep(6000);
                }
            }

            return order;
        }

        /// <summary>
        /// отменяем неудачный ордер
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public static async Task<bool> CancelOrder(NewOrder newOrder)
        {
            
            var canceledOrder = await GetBinanceClient().CancelOrder(newOrder.Symbol, newOrder.OrderId);
            Order order2 = null;
            while (order2 == null || order2.Status != "CANCELED")
            {
                order2 = await GetBinanceClient().GetOrder(canceledOrder.Symbol, canceledOrder.OrderId);
                Thread.Sleep(100);
            }
            
            return true;
        }

        public static async Task<AskAndBid> AskAndBidPairInfo(string pair)
        {
            AskAndBid aab = new AskAndBid();
            
            var asks = await GetLastAsks(pair);
            var bids = await GetLastBids(pair);

            var strPairInfo = $"Пара {pair}; {Environment.NewLine}";

            if (asks != null)
            {
                aab.MaxAsk = asks.Select(ask => ask.Price).OrderByDescending(p => p).FirstOrDefault();
                aab.MinAsk = asks.Select(ask => ask.Price).OrderBy(p => p).FirstOrDefault();
                strPairInfo += $"Запросы на покупку {Environment.NewLine}";
                if (aab.MaxAsk != null)
                    strPairInfo += $"maxAsk  {aab.MaxAsk}; {Environment.NewLine}";
                if (aab.MinAsk != null)
                    strPairInfo += $"minAsk  {aab.MinAsk}; {Environment.NewLine}";
            }

            aab.MaxBid = bids.Select(bid => bid.Price).OrderByDescending(p => p).FirstOrDefault();
            aab.MinBid = bids.Select(bid => bid.Price).OrderBy(p => p).FirstOrDefault();
            strPairInfo += $"Предложения на продажу {Environment.NewLine}";
            strPairInfo += $"maxBids  {aab.MaxBid}; {Environment.NewLine}";
            if (aab.MinBid != null)
                strPairInfo += $"minBids  {aab.MinBid}; {Environment.NewLine}";

            aab.StringView = strPairInfo;
            return aab;
        }

    }
}
