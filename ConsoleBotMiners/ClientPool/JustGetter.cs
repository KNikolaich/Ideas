using System;
using System.Net.Http;
using System.Reflection;
// using System.Web.Helpers;
using System.Web.Script.Serialization;

namespace ClientPool
{
    /// <summary> Просто запросник Get </summary>
    public class JustGetter
    {
        private static string _error = "Error";

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
                {
                    return _error;
                }
            }
        }

        public static T GetValueFromRequiest<T>(string url, string propName)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            var json = GetSomeUrlResult(url);
            if (!string.Equals(json, _error))
            {
                dynamic obj = serializer.Deserialize(json, typeof(object));
                
                
                //(new System.Collections.Generic.Mscorlib_DictionaryDebugView<string, object>(((ClientPool.DynamicJsonConverter.DynamicJsonObject)obj)._dictionary).Items[1]).Value
                if (obj.status == "OK")
                {
                    var dynamicJsonObject = obj.data as DynamicJsonConverter.DynamicJsonObject;
                    if (dynamicJsonObject?.GetProperty(propName) is T)
                        return (T) dynamicJsonObject?.GetProperty(propName);
                    else
                        throw new InvalidCastException($"Невозможно взять свойство {propName} в объекте {obj} и привести его к типу {typeof(T)}");
                }
            }

            throw new EntryPointNotFoundException($"Не найдено свойство {propName} или ответ не вернул нам OK {Environment.NewLine} {json}");
        }
    }
}
