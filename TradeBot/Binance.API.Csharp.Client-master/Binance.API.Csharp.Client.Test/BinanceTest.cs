using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.WebSocket;
using Binance.API.Csharp.Client.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binance.API.Csharp.Client.Test
{
    [TestClass]
    public class BinanceTest
    {
        private static NameValueCollection _appSettings = ConfigurationManager.AppSettings;
        private static ApiClient apiClient = new ApiClient(_appSettings["YourApiKey"], _appSettings["YourApiSecret"]);
        private static BinanceClient binanceClient = new BinanceClient(apiClient, false);

        #region General
        [TestMethod]
        public void TestConnectivity()
        {
            var test = binanceClient.TestConnectivity().Result;
            var res = test == null;
            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void GetServerTime()
        {
            var serverInfo = binanceClient.GetServerTime().Result;
            if (serverInfo != null)
            {
                var serverTime = Models.Helpers.Converters.GeDateTime(serverInfo.ServerTime);
                //if (Equals(DateTime.Now.GetDateTimeFormats('g')[0], serverTime.GetDateTimeFormats('g')[0]))
                //{
                    
                //}
                Assert.AreEqual(DateTime.Now.GetDateTimeFormats('g')[0], serverTime.GetDateTimeFormats('g')[0]);
            }
            Assert.Fail("Время с сервера не вернулось");
        }
        #endregion

        #region Market Data
        [TestMethod]
        public void GetOrderBook()
        {
            var orderBook = binanceClient.GetOrderBook("btcusdt").Result;
            Assert.AreEqual(orderBook.Asks.Count() > 0, true);
            Assert.AreEqual(orderBook.Bids.Count() > 0, true);
        }

        [TestMethod]
        public void GetCandleSticks()
        {
            var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Hours_1, DateTime.Today.AddDays(-1)).Result;
            Assert.AreEqual(candlestick.Count() > 0, true);
        }

        [TestMethod]
        public void GetAggregateTrades()
        {
            var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
            Assert.AreEqual(aggregateTrades.Count(), 500);
        }

        [TestMethod]
        public void GetPriceChange24H()
        {
            var singleTickerInfo = binanceClient.GetPriceChange24H("ETHBTC").Result;

            var allTickersInfo = binanceClient.GetPriceChange24H().Result;
            Assert.AreEqual(allTickersInfo.Count() > 0, true);
        }

        [TestMethod]
        public void GetAllPrices()
        {
            var tickerPrices = binanceClient.GetAllPrices().Result;
            Assert.AreEqual(tickerPrices.Count() > 0, true);
        }

        [TestMethod]
        public void GetOrderBookTicker()
        {
            var orderBookTickers = binanceClient.GetOrderBookTicker().Result;
            Assert.AreEqual(orderBookTickers.Count() > 0, true);
        }
        #endregion

        #region Account Information
        [TestMethod]
        public void PostLimitOrder()
        {
            var buyOrder = binanceClient.PostNewOrderTest("KNCETH", 100m, 0.005m, OrderSide.BUY).Result;
            var sellOrder = binanceClient.PostNewOrderTest("KNCETH", 1000m, 1m, OrderSide.SELL).Result;
            Assert.AreEqual(buyOrder.Symbol, "KNCETH");
            Assert.AreEqual(sellOrder.Symbol, "KNCETH");
        }

        [TestMethod]
        public void PostMarketOrder()
        {
            var buyMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET).Result;
            var sellMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.SELL, OrderType.MARKET).Result;
            Assert.AreEqual(buyMarketOrder.Symbol, "ethbtc");
            Assert.AreEqual(sellMarketOrder.Symbol, "ethbtc");
        }

        [TestMethod]
        public void PostIcebergOrder()
        {
            var icebergOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET, icebergQty: 2m).Result;

            Assert.AreEqual(icebergOrder.Symbol, "ethbtc");
        }

        [TestMethod]
        public void PostNewLimitOrderTest()
        {
            var testOrder = binanceClient.PostNewOrderTest("ethbtc", 1m, 0.1m, OrderSide.BUY).Result;

            Assert.AreEqual(testOrder.Symbol, "ethbtc");
        }

        [TestMethod]
        public void CancelOrder()
        {
            var canceledOrder = binanceClient.CancelOrder("ethbtc", 9137796).Result;
            Assert.AreEqual(canceledOrder.Symbol, "ethbtc");
        }

        [TestMethod]
        public void GetCurrentOpenOrders()
        {
            var openOrders = binanceClient.GetCurrentOpenOrders("ethbtc").Result;
            Assert.AreEqual(openOrders.Any(), true);
        }

        [TestMethod]
        public void GetOrder()
        {
            var order = binanceClient.GetOrder("ethbtc", 8982811).Result;
            Assert.AreEqual(order.Symbol, "ethbtc");
        }

        [TestMethod]
        public void GetAllOrders()
        {
            var allOrders = binanceClient.GetAllOrders("btcusdt").Result;
            Assert.AreEqual(allOrders.Any(), true);
        }

        [TestMethod]
        public void GetAccountInfo()
        {
            var accountInfo = binanceClient.GetAccountInfo().Result;
            Assert.AreEqual(accountInfo.CanTrade, true);
        }

        [TestMethod]
        public void GetTradeList()
        {
            var tradeList = binanceClient.GetTradeList("ethbtc").Result;
        }

        [TestMethod]
        public void Withdraw()
        {
            var withdrawResult = binanceClient.Withdraw("AST", 100m, "@YourDepositAddress").Result;
        }

        [TestMethod]
        public void GetDepositHistory()
        {
            var depositHistory = binanceClient.GetDepositHistory("btc", DepositStatus.Success).Result;
        }

        [TestMethod]
        public void GetWithdrawHistory()
        {
            var withdrawHistory = binanceClient.GetWithdrawHistory("neo").Result;
        }
        #endregion

        #region User stream
        [TestMethod]
        public void StartUserStream()
        {
            var listenKey = binanceClient.StartUserStream().Result.ListenKey;
        }

        [TestMethod]
        public void KeepAliveUserStream()
        {
            var ping = binanceClient.KeepAliveUserStream("@ListenKey").Result;
        }

        [TestMethod]
        public void CloseUserStream()
        {
            var resut = binanceClient.CloseUserStream("@ListenKey").Result;
        }
        #endregion

        #region WebSocket

        #region Depth
        private void DepthHandler(DepthMessage messageData)
        {
            var depthData = messageData;
        }

        [TestMethod]
        public void TestDepthEndpoint()
        {
            binanceClient.ListenDepthEndpoint("ethbtc", DepthHandler);
            Thread.Sleep(50000);
        }

        #endregion

        #region Kline
        private void KlineHandler(KlineMessage messageData)
        {
            var klineData = messageData;
        }

        [TestMethod]
        public void TestKlineEndpoint()
        {
            binanceClient.ListenKlineEndpoint("ethbtc", TimeInterval.Minutes_1, KlineHandler);
            Thread.Sleep(50000);
        }
        #endregion

        #region AggregateTrade
        private void AggregateTradesHandler(AggregateTradeMessage messageData)
        {
            var aggregateTrades = messageData;
        }

        [TestMethod]
        public void AggregateTestTradesEndpoint()
        {
            binanceClient.ListenTradeEndpoint("ethbtc", AggregateTradesHandler);
            Thread.Sleep(50000);
        }

        #endregion

        #region User Info
        private void AccountHandler(AccountUpdatedMessage messageData)
        {
            var accountData = messageData;
        }

        private void TradesHandler(OrderOrTradeUpdatedMessage messageData)
        {
            var tradesData = messageData;
        }

        private void OrdersHandler(OrderOrTradeUpdatedMessage messageData)
        {
            var ordersData = messageData;
        }

        [TestMethod]
        public void TestUserDataEndpoint()
        {
            binanceClient.ListenUserDataEndpoint(AccountHandler, TradesHandler, OrdersHandler);
            Thread.Sleep(50000);
        }
        #endregion

        #endregion
    }
}
