using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace Trader.LiveCoin
{
    public class PostRequest
    {

        public static string Buylimit()
        {
            var parametrs = new Dictionary<string, string>
            {
                {"currencyPair", "BTC/USD"},
                {"price", "60"},
                {"quantity", "0.1"}
            };
            var reqParametrs = new ReqParameters(TypeMethodEnum.POST, "exchange/buylimit", parametrs);
            HttpStatusCode statusCode;
            return reqParametrs.Run(out statusCode);
            //Console.WriteLine("Response Code: " + StatusCode);
            //Console.WriteLine("Response String: " + ResponseFromServer);
        }

    }
}