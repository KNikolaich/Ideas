using System;
using System.Net;
using Newtonsoft.Json;
using PoolsSelector.Data;

namespace PoolsSelector
{
    public abstract class PoolApiBase
    {
        protected string _account;

        protected PoolApiBase(string account, WebProxy proxy = null) : this(proxy)
        {
            _account = account;

        }

        protected PoolApiBase(WebProxy proxy = null)
        {
            Proxy = proxy;
        }

        public WebProxy Proxy { get; set; }

        public abstract float GetShareCoef(string worker = null);

        public abstract float GetAccountBalance();

        public abstract float GetAverageHashrate(DurationTimeEnum duration, string worker = null);


        protected virtual T LoadResponse<T>(RequestMethodEnum requestMethodEnum)
        {
            var url = GetUrl(requestMethodEnum);

            T result = default;
            try
            {
                var response = GetJsonResponse(url);

                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<T>(response);
                    return result;
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                if (!string.IsNullOrWhiteSpace(error) && result == null)
                {
                    result = CastToChild<T>(GetErrorResponse(error));
                    return result;
                }
            }


            return default(T);
        }

        protected string GetJsonResponse(string url)
        {
            string response;
            using (var client = new WebClient())
            {
                if (Proxy != null)
                {
                    WebRequest.DefaultWebProxy = Proxy;
                    client.Proxy = Proxy;
                }

                response = client.DownloadString(new Uri(url));
            }

            return response;
        }


        protected abstract string GetUrl(RequestMethodEnum requestMethodEnum);


        private static T CastToChild<T>(Response.NanopoolApi.Response response)
        {
            var serializedParent = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<T>(serializedParent);
        }

        private static Response.NanopoolApi.Response GetErrorResponse(string error)
        {
            return new Response.NanopoolApi.Response
            {
                Status = false,
                Error = error
            };
        }
    }
}
