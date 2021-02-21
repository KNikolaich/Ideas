using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ClientForPool
{
    /// <summary> Просто запросник Get </summary>
    public class JustGetter
    {
        /// <summary>
        /// Делаем некий запрос
        /// </summary>
        /// <param name="urlStr">полный url запроса</param>
        /// <returns>результат запроса</returns>
        public static string GetSomeUrlResult(string urlStr)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(urlStr);
                var response = client.GetStringAsync(uri).Result;

                if (response.Length > 0)
                {
                     return response;
                }
                else
                    return "Error";
            }
        }
    }
}
