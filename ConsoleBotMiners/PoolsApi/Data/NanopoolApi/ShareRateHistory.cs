using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class ShareRateHistory : Data
	{
		private int _date { get; set; }
		private int _shares { get; set; }

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
	}
}