using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Trader.Model;

namespace Trader.LiveCoin
{
    public class GetRequest
    {
        /// <summary>
        /// Получить информацию за последние 24 часа по конкретной паре валют.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="currencyPair"></param>
        /// <returns>
        /// В ответе есть следующие поля:
        /// max_bid, min_ask - максимальный бид и минимальный аск за последние 24 часа
        /// best_bid, best_ask - лучшие текущие бид и аск</returns>
        public static TResult GetTicker<TResult>(string currencyPair = "")
        {

            var parametrs = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(currencyPair))
            {
                parametrs.Add("currencyPair", currencyPair);
            }
            var response = Response<TResult>(parametrs, "exchange/ticker?");
            return response;
        }

        /// <summary>
        /// Получить информацию о последних сделках (транзакциях) по заданной паре валют.
        /// </summary>
        /// <param name="currencyPair">Идентификатор пары валют. Обязательный параметр</param>
        /// <param name="minutesOrHour">Если true, то информация возвращается за последнюю минуту, если false, то за последний час</param>
        /// <param name="type">Возможные значения: BUY SELL</param>
        /// <returns></returns>
        /// <remarks>Информацию можно получить либо за последний час, либо за последнюю минуту.</remarks>
        public static List<Swap> LastTrades(string currencyPair = "USD/RUR", bool minutesOrHour = false, StyleTickedEnum type = StyleTickedEnum.False)
        {
            
            var parametrs = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(currencyPair))
            {
                parametrs.Add("currencyPair", currencyPair);
            }
            if (type != StyleTickedEnum.False)
            {
                parametrs.Add("type", type.ToString());
            }
            if (minutesOrHour)
            {
                parametrs.Add("minutesOrHour", "true");
            }
            //Возможные значения: BUY SELL
            var response = Response<List<Swap>>(parametrs, "/exchange/last_trades?");
            return response;
        }

        /// <summary>
        /// общий метод запроса
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="parametrs"></param>
        /// <param name="exchangeTicker"></param>
        /// <returns></returns>
        private static TResult Response<TResult>(Dictionary<string, string> parametrs, string exchangeTicker)
        {
            var reqParametrs = new ReqParameters(TypeMethodEnum.GET, exchangeTicker, parametrs);
            HttpStatusCode statusCode;
            var responseFromServer = reqParametrs.Run(out statusCode);

            if (responseFromServer.Contains("errorMessage"))
            {
                return Activator.CreateInstance<TResult>();
            }
            var response = JsonConvert.DeserializeObject<TResult>(responseFromServer);
            return response;
        }

    }

    public enum StyleTickedEnum
    {
        False,
        BUY,
        SELL
    }
}