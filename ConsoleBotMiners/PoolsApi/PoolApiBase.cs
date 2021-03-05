using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoolsApi.Data;
using PoolsApi.Response;

namespace PoolsApi
{
    public abstract class PoolApiBase
    {
        protected PoolApiBase(WebProxy proxy = null)
        {
            Proxy = proxy;
        }

        public WebProxy Proxy { get; set; }

        protected abstract FloatValue GetCurrentHashrate(string account, string worker = null);

        protected abstract FloatValue GetAccountBalance(string account);

        protected abstract float GetAverageHashrate(string account, DurationTimeEnum duration, string worker);


        protected T LoadResponse<T>(string url)
        {
            url = ValidAndRestyleUrl<T>(url);

            T result = default;
            try
            {
                using (var client = new WebClient())
                {
                    if (Proxy != null)
                    {
                        WebRequest.DefaultWebProxy = Proxy;
                        client.Proxy = Proxy;
                    }

                    var response = client.DownloadString(new Uri(url));

                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        result = JsonConvert.DeserializeObject<T>(response);
                        

                        return result;
                    }
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


        protected virtual string ValidAndRestyleUrl<T>(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            return url;
        }


        private static T CastToChild<T>(NanopoolApi.Response.Response response)
        {
            var serializedParent = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<T>(serializedParent);
        }

        private static NanopoolApi.Response.Response GetErrorResponse(string error)
        {
            return new NanopoolApi.Response.Response
            {
                Status = false,
                Error = error
            };
        }
    }
}
