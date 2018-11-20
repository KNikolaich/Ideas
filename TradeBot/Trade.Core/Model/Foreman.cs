using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Trader.Ancillary;
using Trader.LiveCoin;
using Trader.ORMDataModelCode;

namespace Trader.Model
{
    /// <summary>
    /// прораб (управляет строителями)
    /// </summary>
    public class Foreman
    {
        private readonly BuilderCandle _builderCandle;
        private static readonly Dictionary<string, CandleChain> CandleChanes = new Dictionary<string, CandleChain>();

        /// <summary>
        /// Прораб получает цепочку значений продаж и цепочку свечей (если таковые уже есть)
        /// к цепочке свечей приликновываем новые, сформированные по датам продаж
        /// Построители работают по трем направлениями, - 
        /// 1. создание свечей
        /// 2. расчет тенденции
        /// 3. вычисление типа свечи
        /// </summary>
        /// <param name="builderCandle"></param>

        public Foreman(BuilderCandle builderCandle)
        {
            _builderCandle = builderCandle;
            if (_builderCandle.DictionaryPairToCandleChaines == null)
                _builderCandle.DictionaryPairToCandleChaines = CandleChanes;
        }

        /// <summary>
        /// построить цепочку 
        /// (т.к. пока у нас только один строитель, то просто делегируем ему этот процесс и присваиваем себе результат его труда)
        /// </summary>
        /// <param name="lastTrades">результаты торгов</param>
        /// <param name="currencyPair">валютная пара</param>
        /// <param name="interval">время сессии</param>
        public CandleChain Build(List<Swap> lastTrades, string currencyPair, TimeInterval interval)
        {
            return _builderCandle.CreateCandlesChain(lastTrades, currencyPair, interval);
        }

        public bool SaveChain(CandleChain currencyPair)
        {
            //var collection = currencyPair.GetRange(0,5).ToList();
            XpoDefault.Session.Connect();
            XpoDefault.Session.Save(currencyPair.FirstOrDefault());
            XpoDefault.Session.Disconnect();
            return true;
        }

        /// <summary>
        /// события для пар
        /// </summary>
        /// <param name="itemHint">пара</param>
        /// <param name="interval">интервал расчетов</param>
        /// <param name="beSave">сохраняем результаты в БД</param>
        /// <returns>profit</returns>
        public static async Task<string> GetEventsForPair(string itemHint, TimeInterval interval, bool beSave = true)
        {
            var candleChain = await GetCandleChain(itemHint, interval, beSave, null);
            
            return CalcProfit(candleChain?.Predictions);
        }

        /// <summary>
        /// Взять цепочку
        /// </summary>
        /// <param name="pairCurr">валютная пара</param>
        /// <param name="interval">интервал свечи</param>
        /// <param name="beSave">схранять сразу в БД</param>
        /// <returns></returns>
        public static async Task<CandleChain> GetCandleChain(string pairCurr, TimeInterval interval, bool beSave, DateTime? startTime, int limit = 100)
        {
            if (startTime == null)
                startTime = DateTime.Now.AddHours(-4);
            CandleChain candleChain = null;
            //var currencyPair = "USD/RUR";
            var foreman = new Foreman(new BuilderCandle());
            switch (Burse.BurseType())
            {
                case BurseTypeEnum.LiveCoin:
                    var lastTrades = GetRequest.LastTrades(pairCurr);

                    candleChain = foreman.Build(lastTrades, pairCurr, interval);

                    break;
                case BurseTypeEnum.BinanceCoin:

                    var sticks = await Burse.GetBinanceClient().GetCandleSticks(pairCurr, interval, startTime, null, limit);
                    candleChain = foreman.Build(sticks, pairCurr, interval);
                    if (beSave)
                    {
                        OrmDataHelper.Save(candleChain.ToList());
                    }

                    break;
                default:
                    var pairCurrency = Nsi_PairCurrency.FindCurrencyOrCreate(pairCurr);

                    candleChain = new CandleChain(interval, pairCurrency);
                    break;
            }
            return candleChain;
        }

        private CandleChain Build(IEnumerable<Candlestick> sticks, string currencyPair, TimeInterval interval)
        {
            return _builderCandle.CreateCandlesChain(sticks.OrderBy(item =>item.CloseTime).ToList(), currencyPair, interval);
        }

        /// <summary>
        /// Расчет профита по данным в таблице Balance
        /// </summary>
        /// <returns></returns>
        public static string CalcProfit()
        {

            var btcCollection = new XPCollection();

            ((System.ComponentModel.ISupportInitialize)(btcCollection)).BeginInit();
            btcCollection.CriteriaString = "[CurrencyName] = \'BTC\' OR [CurrencyName] = \'USDT\'";
            btcCollection.DisplayableProperties = "ID;Volume;CurrencyName;Date;Price";
            btcCollection.ObjectType = typeof(Trader.Balance);
            btcCollection.Sorting.AddRange(new[] {
                new SortProperty("[Date]", SortingDirection.Ascending)});
            btcCollection.Session = OrmDataHelper.Session;

            ((System.ComponentModel.ISupportInitialize)(btcCollection)).EndInit();
            btcCollection.Load();
           // var balances = OrmDataHelper.GetCollection<Balance>(new DevExpress.Data.Filtering.CriteriaOperatorCollection()
           //   {DevExpress.Data.Filtering.CriteriaOperator.Parse(@"CurrencyName = 'USDT'")
           //DevExpress.Data.Filtering.CriteriaOperator.And(
           //  DevExpress.Data.Filtering.CriteriaOperator.Parse(@"CurrencyName = 'USDT'"),
           // DevExpress.Data.Filtering.CriteriaOperator.Parse(@"CurrencyName = 'BTC'"))
           //   },
           //   10000, new [] {"Date"});
           //
            int countIter = 0;
            int counMarketPlus = 0;
            int countMarketMinus = 0;
            Balance prima = null;
            Balance second;
            var balances = btcCollection.Cast<Balance>();
            foreach (Balance balance in balances)
            {
                countIter++;
                if (countIter % 2 != 0)
                {
                    prima = balance;
                }
                else
                {
                    second = balance;
                    // На заполнении второго, высчитываем профит
                    if (prima != null)
                    {
                        if(second.Price < prima.Price) // цена продажи выше цены покупки
                        {
                            counMarketPlus++;
                        }
                        else
                        {
                            countMarketMinus++;
                        }
                    }

                }
            }

            var currencyNames = balances.Select(bal => bal.CurrencyName).Distinct();



            foreach (var currencyName in currencyNames)
            {
                var curNameBalances = balances.Where(b => b.CurrencyName == currencyName);
                var firsnCur = curNameBalances.FirstOrDefault();
                var LastCur = curNameBalances.LastOrDefault();
                if (firsnCur != null && LastCur != null)
                {
                    LogHolder.MainLogInfo($"Валюты {currencyName} было {firsnCur.Volume.ToString("g")}, а стало {LastCur.Volume.ToString("g")}");
                }
            }
            var message =
                $"Всего сделок было проведено {countMarketMinus + counMarketPlus}. Из них {counMarketPlus} удачных, а {countMarketMinus} неудачных";
            LogHolder.MainLogInfo(message);
            return message;
        }

        /// <summary>
        /// Расчет профита по данным в таблице Balance
        /// </summary>
        /// <returns></returns>
        private static string CalcProfit(List<Prediction> ds)
        {
            decimal quantityBtc = 0;

            decimal beginUsd = 50; // начальная сумма бачинских

            decimal summ = beginUsd;

            decimal lastPriceBtc = 0;

            int countIter = 0;

            foreach (Prediction prediction in ds.OrderBy(p => p.Candle.StartDate))
            {
                if (prediction.Conclusion.Contains("покупай"))
                {
                    if (prediction.Volume != null && summ != 0)
                    {
                        quantityBtc = (summ) / prediction.Volume.Value;
                        summ = 0;
                    }
                }
                else if (prediction.Conclusion.Contains("продавай"))
                {
                    if (prediction.Volume != null && quantityBtc != 0)
                    {
                        summ = prediction.Volume.Value * quantityBtc;
                        countIter++;
                    }
                }
                lastPriceBtc = prediction.Candle.ClosePrice;
            }
            if (summ == 0 && quantityBtc != 0)
            {
                summ = quantityBtc * lastPriceBtc; // фейковый результат, в случае, если последней была покупка, а не продажка
            }

            var resultUsd = summ - beginUsd; // приработок в результате торгов

            var resultInPercent = resultUsd * 100 / beginUsd; // в процентном соотношении относительно начальной суммы

            var message =
                $"Сделано {countIter} операций. Приработок в результате торгов {resultUsd.ToString("C")} - это {resultInPercent.ToString("F")}% ";
            LogHolder.MainLogInfo(message);
            return message;
        }

        /// <summary>
        /// Чистим цепь
        /// </summary>
        /// <param name="pairCurrency"></param>
        /// <param name="timeInterval"></param>
        public static void ClearChain(string pairCurrency, TimeInterval timeInterval)
        {
            var chainKey = GetCandleChainKey(pairCurrency, timeInterval);
            if (CandleChanes.ContainsKey(chainKey.ToString()))
            {
                CandleChanes[chainKey.ToString()].Clear();
                CandleChanes.Remove(chainKey.ToString());
            }
           //throw new NotImplementedException();
        }

        private static CandleChainKey GetCandleChainKey(string pairCurrency, TimeInterval timeInterval)
        {
            var chainKey = new CandleChainKey(Converters.IntervalToTimespan(timeInterval),
                Nsi_PairCurrency.FindCurrencyOrCreate(pairCurrency));
            return chainKey;
        }

        public static CandleChain GetCandleChane(string pairCurr, TimeInterval timeInterval)
        {
            var chainKey = GetCandleChainKey(pairCurr, timeInterval);
            if (CandleChanes.ContainsKey(chainKey.ToString()))
            {
                return CandleChanes[chainKey.ToString()];
            }

            return null;
        }
    }
}