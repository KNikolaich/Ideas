using Newtonsoft.Json;

namespace PoolsSelector.Response
{
    public class StringValue : NanopoolApi.Response
    {
        private string _data { get; set; }

        [JsonProperty("data")]
        public string Data
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