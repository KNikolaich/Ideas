using Newtonsoft.Json;

namespace PoolsSelector.Response
{
    public class IntValue : NanopoolApi.Response
    {
        private int _data { get; set; }

        [JsonProperty("data")]
        public int Data
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