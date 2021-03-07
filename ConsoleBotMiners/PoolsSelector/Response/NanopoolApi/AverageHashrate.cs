using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
    public class AverageHashrate : Response
    {
        private Data.NanopoolApi.AverageHashrate _data { get; set; }

        [JsonProperty("data")]
        public Data.NanopoolApi.AverageHashrate Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (_data == value) return;

                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
    }
}