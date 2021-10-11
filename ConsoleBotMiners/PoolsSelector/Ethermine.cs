using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoolsSelector.Data;

namespace PoolsSelector
{
    public class Ethermine : PoolApiBase
    {

        public Ethermine(string account)
        {
            _account = account;
        }

        public override float GetCurrentHashrate(string worker = null)
        {
            var response = LoadResponse<float?>(RequestMethodEnum.currentHashrate).GetValueOrDefault(); 
            return response;
        }

        public override float GetAccountBalance()
        {
            var response = LoadResponse<long?>(RequestMethodEnum.unpaid);
            if (response.HasValue && response != 0)
            {
                return response.Value / 1000000000000000000f;
            }
            return 0f;
        }

        public override float GetAverageHashrate(DurationTimeEnum duration, string worker)
        {
            var response = LoadResponse<float?>(RequestMethodEnum.averageHashrate);
            return response ?? 0f;
        }

        protected override string GetUrl(RequestMethodEnum requestMethodEnum)
        {
            return EthermineStatics.GetUrl(_account, requestMethodEnum);
        }

        protected override T LoadResponse<T>(RequestMethodEnum requestMethodEnum)
        {

            var jsonResponse = GetJsonResponse(GetUrl(requestMethodEnum));
            if (!string.Equals(jsonResponse.Length, 0))
            {
                JObject obj = JsonConvert.DeserializeObject(jsonResponse, typeof(object)) as JObject;

                if (obj == null || Equals(obj["status"].ToString(), "ERROR"))
                {
                    throw new HttpRequestException("Ошибка запроса");
                }
                //(new System.Collections.Generic.Mscorlib_DictionaryDebugView<string, object>(((ClientPool.DynamicJsonConverter.DynamicJsonObject)obj)._dictionary).Items[1]).Value
                if (Equals(obj["status"].ToString(), "OK"))
                {
                    if (obj["data"].ToString() != "NO DATA" && obj["data"] is JObject)
                    { 
                        var res = ((JObject)obj["data"]).Property(requestMethodEnum.ToString()).Value;

                        if (res.Value<T>() != null && !string.IsNullOrEmpty(res.ToString()))
                            return res.Value<T>();
                    }

                    throw new InvalidCastException($"Невозможно взять свойство {requestMethodEnum.ToString()} в объекте {obj}");
                }
            }

            throw new EntryPointNotFoundException($"Не найдено свойство {requestMethodEnum.ToString()} или ответ не вернул нам OK {Environment.NewLine} {jsonResponse}");
        }

    }
}
