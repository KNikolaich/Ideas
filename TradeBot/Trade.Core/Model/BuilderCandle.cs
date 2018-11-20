using System.Collections.Generic;
using System.Linq;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using Binance.API.Csharp.Client.Models.Market;
using DevExpress.Data.Filtering;
using Trader.Ancillary;
using Trader.ORMDataModelCode;

namespace Trader.Model
{
    /// <summary>
    /// Построитель свечей, - часть паттерна Builder
    /// </summary>
    public class BuilderCandle
    {
        public Dictionary<string, CandleChain> DictionaryPairToCandleChaines { get; set; }

        /// <summary>
        /// построить цепочку 
        /// </summary>
        /// <param name="sticks">готовые свечи</param>
        /// <param name="currencyPair">валютная пара</param>
        /// <param name="interval">время сессии</param>
        /// <remarks>проверяем , нет ли в словаре уже такой цепи, добавляем по необходимости
        /// делаем новую це</remarks>
        public CandleChain CreateCandlesChain(List<Candlestick> sticks, string currencyPair, TimeInterval interval)
        {
            var chain = GetOrCreateChain(currencyPair, interval);
            chain.AddCandlesFromSticks(sticks);
            chain.Visited();
            return chain;
        }

        /// <summary>
        /// построить цепочку 
        /// </summary>
        /// <param name="lastTrades">результаты торгов</param>
        /// <param name="currencyPair">валютная пара</param>
        /// <param name="interval">время сессии</param>
        /// <remarks>проверяем , нет ли в словаре уже такой цепи, добавляем по необходимости
        /// делаем новую це</remarks>
        public CandleChain CreateCandlesChain(List<Swap> lastTrades, string currencyPair, TimeInterval interval)
        {
            var chain = GetOrCreateChain(currencyPair, interval);
            chain.AddCandlesFromSwops(lastTrades);
            chain.Visited();
            return chain;
        }

        private CandleChain GetOrCreateChain(string currencyPair, TimeInterval interval)
        {
            CandleChain chain = null;

            var nsiPairCurrency = Nsi_PairCurrency.FindCurrencyOrCreate(currencyPair);

            if (nsiPairCurrency != null)
            {
                var newCcKey = new CandleChainKey(Converters.IntervalToTimespan(interval), nsiPairCurrency);
                if (DictionaryPairToCandleChaines.ContainsKey(newCcKey.ToString()))
                {
                    chain = DictionaryPairToCandleChaines[newCcKey.ToString()];
                }
                else
                {
                    chain = new CandleChain(newCcKey);
                    DictionaryPairToCandleChaines.Add(newCcKey.ToString(), chain);
                    LoadChain(currencyPair, chain);
                }
            }
            return chain;
        }

        private void LoadChain(string cPair, CandleChain chain)
        {

            var nsiPairCurrency = Nsi_PairCurrency.FindCurrencyOrCreate(cPair);

            if (nsiPairCurrency != null)
            {
                //currency.Candles.Load();

                CriteriaOperator criteriaOperator = null;
                
                var lodCandle = chain.LastOrDefault(); // цепь уже начата, грузим продолжение
                if (lodCandle != null) 
                {
                    criteriaOperator =
                        CriteriaOperator.And(new []
                        {
                            CriteriaOperator.Parse($"EndDate > '{lodCandle.EndDate}'"),
                            CriteriaOperator.Parse($"Currency.Exchange.Name='{Burse.CurrentName}'")
                        });
                }
                else
                {
                    criteriaOperator =
                        CriteriaOperator.And(CriteriaOperator.Parse($"Currency.Exchange.Name='{Burse.CurrentName}'"));
                }
                var candles = OrmDataHelper.GetCollection<Candle>(criteriaOperator);

                chain.AddRange(candles);

            }

        }
    }
}