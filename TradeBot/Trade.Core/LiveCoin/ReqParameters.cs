using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Trader.LiveCoin
{
    public class ReqParameters
    {
        public ReqParameters(TypeMethodEnum type, string method, Dictionary<string, string> parameters)
        {
            TypeMethod = type;
            Method = method.TrimEnd('?');
            Parameters = parameters;
        }

        private static string ApiKey { get { return "gJx7Wa7qXkPtmTAaK3ADCtr6m5rCYYMy"; } }

        private static string SecretKey { get { return "8eLps29wsXszNyEhOl9w8dxsOsM2lTzg"; } }

        public Dictionary<string, string> Parameters { get; set; }

        public string Method { get; set; }

        private string Uri { get { return $"https://api.livecoin.net/{Method}"; } }

        public TypeMethodEnum TypeMethod { get; internal set; }

        string GetHttpParameters()
        {
            string str = "";
            foreach(var param in Parameters)
            {
                str += $"{param.Key}={param.Value}&";
            }
            str = str.TrimEnd('&');
            str = str.Replace("/", "%2F");
            str = str.Replace("@", "%40");
            str = str.Replace(";", "%3B");
            return str;
        }

        internal string GetSign()
        {
            return HashHMAC(SecretKey, GetHttpParameters()).ToUpper();
        }

        private static string HashHMAC(string key, string message)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return ByteArrayToString(hashmessage);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        public string Run(out HttpStatusCode statusCode)
        {

            statusCode = HttpStatusCode.OK;
            string responseFromServer;
            string requestUri = Uri;
            var parameters = GetHttpParameters();
            if (TypeMethod == TypeMethodEnum.GET)
            {
                if (!string.IsNullOrEmpty(parameters))
                {
                    requestUri = Uri + "?" + parameters;
                }
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = TypeMethod.ToString();
            request.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = null;
            if (TypeMethod == TypeMethodEnum.POST)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(parameters);
            
                request.ContentLength = bytes.Length;
                request.Headers["Api-Key"] = ApiKey;
                request.Headers["Sign"] = GetSign();
            
                dataStream = request.GetRequestStream();
                dataStream.Write(bytes, 0, bytes.Length);
            }
            WebResponse webResponse = null;
            try
            {
                webResponse = request.GetResponse();
                dataStream = webResponse.GetResponseStream();
                using (StreamReader streamReader = new StreamReader(dataStream))
                {
                    responseFromServer = streamReader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    dataStream = ex.Response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(dataStream);
                    statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    responseFromServer = ex.Message;
                }
                else
                {
                    statusCode = HttpStatusCode.ExpectationFailed;
                    responseFromServer = "Неизвестная ошибка";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                statusCode = HttpStatusCode.ExpectationFailed;
                responseFromServer = "Неизвестная ошибка";
            }
            finally
            {
                dataStream?.Close();
                webResponse?.Close();
            }
            return responseFromServer;
        }


    }

    public enum TypeMethodEnum
    {
        Unknow = 0,
        POST = 1,
        GET = 2
    }
}
