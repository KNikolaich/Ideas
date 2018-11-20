using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Models.Account;
using Binance.API.Csharp.Client.Models.Enums;
using Trader.LiveCoin;

namespace Trader.Ancillary
{
    /// <summary>
    /// Рыночные операции
    /// </summary>
    public class Market
    {
        private readonly List<BalancePair> _balance;

        public Market(params BalancePair[] balance)
        {
            _balance = balance.ToList();
        }

        /// <summary> покупаем </summary>
        public async void Order(Prediction prediction, bool tradeLife, StyleTickedEnum orderStyle)
        {
            short iter = 0;
            bool needOrder = true;
            while (needOrder && iter < 4)
            {
                try
                {
                    iter++;
                    foreach (var pair in _balance)
                    {

                        if (tradeLife)
                        {
                            bool filledOrder = false;
                            var newOrder = await PostRealOrder(orderStyle, pair);
                            
                            var order = await Burse.OrderIsExecuteInLimitTime(newOrder);

                            if (order != null)
                            {
                                if (order.Status == "FILLED" && order.ExecutedQty == order.OrigQty) // ордер выполнен за минуту полностью
                                {
                                    await SaveBalances(pair, order.Price);
                                    LogHolder.WarningLogInfo(
                                        $"{orderStyle} \tна {order.ExecutedQty.ToString("G6")} \tпо цене {order.Price.ToString("C")} \t{prediction.Interpretation}");
                                    filledOrder = true;
                                    //break; // все ок, выходим из цикла for
                                }
                                else
                                {
                                    LogHolder.WarningLogInfo($"К сожалению, ордер за минуту не был исполнен!");
                                    await Burse.CancelOrder(newOrder);

                                }
                            }

                            if (!filledOrder)
                            {
                                var marketOrder = await PostRealOrder(orderStyle, pair, OrderType.MARKET);
                                if (marketOrder != null)
                                {
                                    var orderExec = await Burse.OrderIsExecuteInLimitTime(marketOrder);

                                    if (orderExec != null && orderExec.Status == "FILLED" && orderExec.ExecutedQty == orderExec.OrigQty)
                                    {
                                        LogHolder.WarningLogInfo($"исполнен по РЫНКУ ${orderExec.ExecutedQty.ToString("G6")} из ${orderExec.OrigQty.ToString("C")}");
                                        await SaveBalances(pair, orderExec.Price);
                                        break; // все ок, выходим из цикла for
                                    }
                                }
                            }
                            else
                            {
                                needOrder = false;
                            }
                        }
                        else if (prediction == null || prediction.Conclusion.Contains(pair.TailName.ToString()))
                        {

                            Candle candle = prediction != null
                                ? prediction.Candle
                                : Candle.CreateFake(10000m, "btcusdt");
                            if (orderStyle == StyleTickedEnum.BUY)
                            {
                                pair.Buy(candle);
                            }
                            else if (orderStyle == StyleTickedEnum.SELL)
                            {
                                pair.Sell(candle);
                            }

                            needOrder = false;
                        }
                    }

                }
                catch (Exception e)
                {
                    LogHolder.ErrorLogInfo(e);
                    //throw;
                }

            }

        }



        internal static async Task<NewOrder> PostRealOrder(StyleTickedEnum styleTicked, BalancePair pair,
            OrderType type = OrderType.LIMIT)
        {
            NewOrder resultOrder = null;
            var pairCurr =
                pair.Second.CurrName.ToLower() +
                pair.Prima.CurrName.ToLower(); //Settings.Default["PairCurrency"].ToString();
            //var price = GetMarketPrice(styleTicked, pairCurr).Result;

            await Fill(pair);
            var price = await BalancePair.GetBuyOrSellPrice(pair.CurrencyPair, styleTicked);

            TargetEnum target = TargetEnum.Undefine;
            while (target == TargetEnum.Undefine)
            {
                try
                {
                    switch (styleTicked)
                    {
                        case StyleTickedEnum.BUY:
                            if (pair.Prima.Volume > 0)
                            {

                                var quant = decimal.Floor(pair.Prima.Volume / price * 1000000) / 1000000;
                                if (quant > 0)
                                {
                                    LogHolder.WarningLogInfo($"Покупка по цене {price.ToString("G")}");
                                    resultOrder = await Burse.PostNewOrder(pairCurr, quant, type == OrderType.LIMIT ? price : 0m, OrderSide.BUY, type);
                                    target = TargetEnum.WasMet;
                                }
                                else
                                {
                                    LogHolder.MainLogInfo(
                                        $"Попытка реальной покупки, - недостаточно {pair.Prima.CurrName} ({pair.Prima.Volume})!");
                                    target = TargetEnum.Unreachable;
                                }
                            }

                            break;
                        case StyleTickedEnum.SELL:
                            if (pair.Second.Volume > 0)
                            {

                                var qunt = decimal.Floor(pair.Second.Volume * 1000000) / 1000000;
                                if (qunt > 0)
                                {
                                    LogHolder.WarningLogInfo($"Продажа по цене {price.ToString("G")}");
                                    resultOrder = await Burse.PostNewOrder(pairCurr, qunt, type == OrderType.LIMIT ? price : 0m, OrderSide.SELL, type);
                                    target = TargetEnum.WasMet;
                                }
                                else
                                {
                                    LogHolder.MainLogInfo(
                                        $"Попытка реальной продажи, - недостаточно {pair.Second.CurrName} ({pair.Second.Volume})!");
                                    target = TargetEnum.Unreachable;
                                }
                            }

                            break;
                    }
                }
                catch (Exception e)
                {
                    LogHolder.ErrorLogInfo(e);
                    if (e.Message.Contains("Api Error Code: -2010") ||
                        (e.InnerException != null && e.InnerException.Message.Contains("Api Error Code: -2010")))
                    {

                        LogHolder.DebugLogInfo("Недостаточно средств на счету");
                        target = TargetEnum.Unreachable;
                    }
                    else if (e.Message.Contains("Api Error Code: -1013") ||
                             (e.InnerException != null && e.InnerException.Message.Contains("Api Error Code: -1013")))
                    {
                        LogHolder.DebugLogInfo("превышен минимальный порог сделки");
                        target = TargetEnum.WasNotMet;
                    }
                    else
                    {
                        target = TargetEnum.WasNotMet;
                    }

                }

            }

            return resultOrder;
        }

        internal static async Task SaveBalances(BalancePair pair, decimal price, bool filling = true)
        {
            try
            {
                if (filling)
                {
                    await Fill(pair);
                }

                PreperingAndSave(pair.Prima, price, filling);
                PreperingAndSave(pair.Second, price, filling);
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
            }
        }

        private static void PreperingAndSave(BalancePair.CurrencyVolume currencyVolume, decimal price, bool filling)
        {
            if (currencyVolume.Volume > 0)
            {
                if (currencyVolume.CurrName == "USDT" && currencyVolume.Volume > 0.01m
                    || currencyVolume.CurrName == "BTC" && currencyVolume.Volume > 0.0001m
                ) // если валюта типа доллар объемом меньше цента, - считаем её нулем
                {
                    BalancePair.SaveBalance(currencyVolume, DateTime.Now, price,
                        !filling); // не смогли свершить сделку, - это фейловый прайс
                }
            }
        }


        public static async Task<Market> GetDefault(BalanceTailEnum balanceTail, bool onlyViewMode)
        {
            var balancePair = new BalancePair("USDT", onlyViewMode? 50m : 0m, "BTC", 0m, balanceTail);

            if (!onlyViewMode)
            {
                await Fill(balancePair);
            }

            var market = new Market(balancePair); // начальные параметры фейкового баланса
            return market;
        }

        private static async Task Fill(BalancePair balancePair)
        {
            var ai = await Burse.GetAccountInfo();
            foreach (var balance in ai.Balances)
            {
                if (balance.Free != 0m)
                {
                    if (balance.Asset == balancePair.Prima.CurrName)
                    {
                        balancePair.Prima.Volume = balance.Free;
                    }
                    else if (balance.Asset == balancePair.Second.CurrName)
                    {
                        balancePair.Second.Volume = balance.Free;
                    }
                }
            }
        }

    }
}

