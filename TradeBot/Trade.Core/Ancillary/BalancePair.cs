using System;
using System.Linq;
using System.Threading.Tasks;
using Trader.LiveCoin;
using Trader.ORMDataModelCode;
using Trader.Properties;

namespace Trader.Ancillary
{
    /// <summary> баланс пары </summary>
    public class BalancePair
    {
        public BalancePair(string primaCurrName, decimal primaVolume, string secondCurrName, decimal secondVolume, BalanceTailEnum tailName)
        {
            TailName = tailName;
            _prima = new CurrencyVolume(primaCurrName, primaVolume);
            _second = new CurrencyVolume(secondCurrName, secondVolume);
        }

        /// <summary> Предназначение части </summary>
        public BalanceTailEnum TailName { get; }

        #region Fields

        /// <summary> объем первой валюты </summary>
        private CurrencyVolume _prima;
        /// <summary> объем второй валюты </summary>
        private CurrencyVolume _second;

        #endregion

        /// <summary> объем первой валюты </summary>
        public CurrencyVolume Prima => _prima;

        /// <summary> объем второй валюты </summary>
        public CurrencyVolume Second => _second;

        /// <summary> название валютной пары </summary>
        public string CurrencyPair => Second.CurrName + Prima.CurrName;

        #region Methods

        /// <summary>
        /// меняем валюту 1 на валюту 2 
        /// </summary>
        /// <param name="candle"></param>
        internal void Buy(Candle candle)
        {
            if (_prima.Volume == 0)
            {
                LogHolder.TraceLogInfo($"покупать надо, а счет {_prima.CurrName} нулевой.");
            }
            else
            {
                var closePrice = GetBuyOrSellPrice(candle, StyleTickedEnum.BUY).Result;
                var cost = _prima.Volume; // стоимость
                _prima.Volume -= cost;
                var quantity = cost / closePrice; // количество
                _second.Volume += quantity;// Добавили количество в докупленную 
                SaveBalance(_second, candle.StartDate, candle.ClosePrice);
                var messageLog =
                    $"ПОКУПКА {candle.StartDate:dd-MMM HH:mm}. Price: {closePrice.ToString("G6")}\t| {ToString()}";

                LogHolder.MainLogInfo(messageLog);
            }
        }

        /// <summary>
        /// меняем валюту 2 на валюту 1
        /// </summary>
        /// <param name="candle"></param>
        public void Sell(Candle candle)
        {

            if (_second.Volume == 0)
            {
                LogHolder.TraceLogInfo($"продавать надо, а счет {_second.CurrName} нулевой.");
            }
            else
            {
                var closePrice = GetBuyOrSellPrice(candle, StyleTickedEnum.SELL).Result;
                var quantity = _second.Volume; // количество
                _second.Volume -= quantity;
                var cost = quantity * closePrice; // стоимость

                _prima.Volume += cost;// Добавили стоимость в докумленную 

                SaveBalance(_prima, candle.StartDate, candle.ClosePrice);
                var messageLog =
                    $"ПРОДАЖА {candle.StartDate:dd-MMM HH:mm}. Price: {closePrice.ToString("G6")}\t| {ToString()}";

                LogHolder.MainLogInfo(messageLog);
            }
        }
        

        /// <summary> цена закупки, должна вычисляться по тому, как мы считаем возможным тороговать </summary>
        /// <param name="candle"></param>
        /// <returns></returns>
        internal async Task<decimal> GetBuyOrSellPrice(Candle candle, StyleTickedEnum styleTicked)
        {
            var price = candle.OpenPrice;
            //TODO если candle исторический, - берем следующий candle и смотрим на цену его открытия (почему открытия, - потому что мы как бы стараемся актуально действовать)
            // если candle последний и новее уже не будет, берем ask или bid
            //var timeSpan = candle.EndDate - candle.StartDate;
            if (candle.EndDate > DateTime.Now && candle.Currency != null)
            {
                var currencyName = candle.Currency.Name;
                price = await GetBuyOrSellPrice(currencyName, styleTicked);
            }
            
            return price;
            
        }

        internal static async Task<decimal> GetBuyOrSellPrice(string currencyName, StyleTickedEnum styleTicked)
        {
            decimal price = 0;

            var pairInfo = await Burse.AskAndBidPairInfo(currencyName);
            switch (styleTicked)
            {
                case StyleTickedEnum.SELL:


                    //var lastBid = await Burse.GetLastBids(currencyName);
                    if (pairInfo.MinAsk != null)
                        price = pairInfo.MinAsk.Value;
                    break;
                case StyleTickedEnum.BUY:
                    if (pairInfo.MaxBid != null)
                        price = pairInfo.MaxBid.Value;
                    break;
                case StyleTickedEnum.False:
                    break;
            }
            return price;
        }

        #endregion


        #region Override and ancillary

        public override string ToString()
        {
            return $"{_prima.Volume.ToString("G7")} {_prima.CurrName} и {_second.Volume.ToString("G7")} {_second.CurrName}.";
        }


        public static void SaveBalance(CurrencyVolume currencyVolume, bool fake = true)
        {
            SaveBalance(currencyVolume, currencyVolume.Date, currencyVolume.Price, fake);
        }

        internal static void SaveBalance(CurrencyVolume currencyVolume, DateTime date, decimal price, bool fake = true)
        {
            OrmDataHelper.Save(new Balance(OrmDataHelper.Session)
            {
                CurrencyName = currencyVolume.CurrName,
                Volume = currencyVolume.Volume,
                IsFake = fake,
                Date = date,
                Price = price

                //Prediction = candle // это конда надо будет всё сохранять
            });
        }


        /// <summary>
        /// вспомогательная струкрута
        /// </summary>
        public class CurrencyVolume
        {
            public CurrencyVolume(string currName, decimal volume)
            {
                CurrName = currName;
                Volume = volume;
            }

            public CurrencyVolume(string currName, decimal volume, DateTime startDate, decimal price) : this(currName, volume)
            {
                Date = startDate;
                Price = price;
            }

            public string CurrName { get; set; }
            public decimal Volume { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
        }

        #endregion
    }
}
