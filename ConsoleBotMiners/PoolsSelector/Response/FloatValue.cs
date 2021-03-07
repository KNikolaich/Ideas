using Newtonsoft.Json;

namespace PoolsSelector.Response
{
    public class FloatValue : NanopoolApi.Response
    {
        private float _data { get; set; }

        [JsonProperty("data")]
        public float Data
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