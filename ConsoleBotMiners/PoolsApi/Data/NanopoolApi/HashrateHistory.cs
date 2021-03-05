using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class HashrateHistory : Data
	{
		private int _date { get; set; }
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