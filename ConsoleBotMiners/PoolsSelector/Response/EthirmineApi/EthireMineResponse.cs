using Newtonsoft.Json;

namespace PoolsSelector.Response.EthirmineApi
{
    public class EthireMineResponse<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
