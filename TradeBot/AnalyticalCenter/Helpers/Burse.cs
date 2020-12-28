using Binance.API.Csharp.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace AnalyticalCenter.Helpers
{
    class Burse
    {
        private static BinanceClient _binanceClient;
        private static string YourApiKey = "g418u6xsd7KdXLYgWiVQfwQmiY1WH066iWvu2MEWiZSQA2YnXj0npkw3zsSfn1jX";
        private static string YourSecretKey = "sV6i1af8ygigEh53gpf3zEKxHuwuZHe48TywePHwkodrHlQu0kzUssT8XUN1draI";

        /// <summary>
        /// Взять клиента бинанс биржи
        /// </summary>
        /// <returns></returns>
        public static BinanceClient GetBinanceClient()
        {
            if (_binanceClient == null)
            {

                string apiSecret;
                string apiKey;
                if (!string.IsNullOrEmpty(YourApiKey))
                {
                    apiKey = YourApiKey;
                    apiSecret = YourSecretKey;
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

    }
}
