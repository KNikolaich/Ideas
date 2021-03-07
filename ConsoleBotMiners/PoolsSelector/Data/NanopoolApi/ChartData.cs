using Newtonsoft.Json;

namespace PoolsSelector.Data.NanopoolApi
{
    public class ChartData : Data
    {
        private int _date { get; set; }
        private int _shares { get; set; }
        private int _hashrate { get; set; }

        [JsonProperty("date")]
        public int Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date == value) return;

                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        [JsonProperty("shares")]
        public int Shares
        {
            get
            {
                return _shares;
            }

            set
            {
                if (_shares == value) return;

                _shares = value;
                OnPropertyChanged(nameof(Shares));
            }
        }

        [JsonProperty("hashrate")]
        public int Hashrate
        {
            get
            {
                return _hashrate;
            }

            set
            {
                if (_hashrate == value) return;

                _hashrate = value;
                OnPropertyChanged(nameof(Hashrate));
            }
        }
    }
}