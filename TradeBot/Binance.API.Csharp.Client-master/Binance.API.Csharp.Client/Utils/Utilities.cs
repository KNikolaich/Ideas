﻿using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.General;

namespace Binance.API.Csharp.Client.Utils
{
    /// <summary>
    /// Utility class for common processes. 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Gets a HMACSHA256 signature based on the API Secret.
        /// </summary>
        /// <param name="apiSecret">Api secret used to generate the signature.</param>
        /// <param name="message">Message to encode.</param>
        /// <returns></returns>
        public static string GenerateSignature(string apiSecret, string message)
        {
            var key = Encoding.UTF8.GetBytes(apiSecret);
            string stringHash;
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                stringHash = BitConverter.ToString(hash).Replace("-", "");
            }

            return stringHash;
        }

        /// <summary>
        /// Gets a timestamp in milliseconds.
        /// </summary>
        /// <returns>Timestamp in milliseconds.</returns>
        public static string GenerateTimeStamp(DateTime baseDateTime)
        {
            var dtOffset = new DateTimeOffset(baseDateTime);
            return dtOffset.ToUnixTimeMilliseconds().ToString();
        }

        public static async System.Threading.Tasks.Task<string> GenerateTimeStamp(ApiClient apiClient)
        {
            try
            {
                //return GenerateTimeStamp(DateTime.Now.ToUniversalTime());
                var dateTask = await apiClient.CallAsync<ServerInfo>(ApiMethod.GET, EndPoints.CheckServerTime, false);
                return dateTask.ServerTime.ToString();
            }
            catch
            {
                return GenerateTimeStamp(DateTime.Now.ToUniversalTime());
            }
        }
        /// <summary>
        /// Gets an HttpMethod object based on a string.
        /// </summary>
        /// <param name="method">Name of the HttpMethod to create.</param>
        /// <returns>HttpMethod object.</returns>
        public static HttpMethod CreateHttpMethod(string method)
        {
            switch (method.ToUpper())
            {
                case "DELETE":
                    return HttpMethod.Delete;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "GET":
                    return HttpMethod.Get;
                default:
                    throw new NotImplementedException();
            }
        }
        

    }
}
