using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Models.Account;

namespace Trader.Ancillary
{
    public class ResultCalculator
    {
        decimal deltapips = 0m;
        //decimal summBuy = 0m;
        //decimal summSale = 0m;
        decimal iCount = 0;
        decimal iCountPlus = 0;
        decimal iCountMinus = 0;
        private string _result = "";//$"Операций всего было:{enumerable.Count}";;
        /// <summary>
        /// Берем за указанный период операции. Складываем все продажи, складываем все покупи. 
        /// Вычисляем дельту. берем следующую покупку и продажу.
        /// </summary>
        /// <param name="pairCurr"></param>
        /// <param name="startDate">начало</param>
        /// <param name="endDate">конец</param>
        /// <returns></returns>
        public async Task<string> CalculateResult(string pairCurr, DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue)
            {
                return "Необходимо заполнить дату начала расчета!";
            }
            if (endDate.HasValue && (endDate.Value.Date < DateTime.Now.AddDays(-360) || startDate > endDate))
            {
                endDate = null;
            }
            var orders = await Burse.GetBinanceClient().GetBetweenOrders(pairCurr, startDate, endDate);

            var enumerable = orders.ToList();

            Order lastOrder = null;

            var buyPrice = 0m;

            foreach (var order in enumerable.OrderBy(order => order.CalcTime))
            {
                if (order.Status == "FILLED")
                {
                    if (order.Side == "BUY")
                    {
                        deltapips = await GetDeltapips(lastOrder, buyPrice, deltapips);
                        buyPrice = await GetPriceForOrder(order);
                        //summBuy += order.OrigQty;
                    }
                    else
                    {
                        //summSale += order.OrigQty;
                    }

                    lastOrder = order;
                }

            }

            deltapips = await GetDeltapips(lastOrder, buyPrice, deltapips);

            _result += $"{Environment.NewLine}Всего за период поднято:{deltapips.ToString("#####.##")} пунктов.{Environment.NewLine}Произведено {iCount} операций.{Environment.NewLine}Положительных: {iCountPlus} отрицаительных {iCountMinus}.";


            return _result;
        }

        /// <summary>
        /// Ордет может быть лимитным, а может быть по маркету
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task<decimal> GetPriceForOrder(Order order)
        {
            return order.Price != 0m ? order.Price : await Burse.GetPriceForMarketOrder(order);
        }

        /// <summary>
        /// Метод расчитывает дельту пипсов, а так же добавляет в текст результата текущую куплю/продажу
        /// </summary>
        /// <param name="lastOrder"></param>
        /// <param name="buyPrice"></param>
        /// <param name="deltapips"></param>
        /// <returns></returns>
        private async Task<decimal> GetDeltapips(Order lastOrder, decimal buyPrice, decimal deltapips)
        {
            if (lastOrder != null && lastOrder.Side == "SELL")
            {
                if (buyPrice > 0)
                {
                    var pips = await GetPriceForOrder(lastOrder) - buyPrice;
                    deltapips += pips;
                    _result +=
                        $"{Environment.NewLine}{lastOrder.CalcTime.ToString("g")} \t{pips.ToString("F")} \t {(pips > 0 ? "YES" : "НЕТ")}: {buyPrice.ToString("#####.###")} -> {lastOrder.Price.ToString("#####.###")}";
                    if (pips > 0)
                    {
                        iCountPlus++;
                    }
                    else
                    {
                        iCountMinus++;
                    }

                    iCount++;
                }

                //summSale = 0;
                //summBuy = 0;
            }

            return deltapips;
        }
    }
}
