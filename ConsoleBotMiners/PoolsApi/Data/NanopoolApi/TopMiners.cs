using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class TopMiners : Data
	{
		private int _hashrate { get; set; }
		private string _adress { get; set; }

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

		[JsonProperty("address")]
		public string Address
		{
			get
			{
				return _adress;
			}

			set
			{
				if (_adress == value) return;

				_adress = value;
				OnPropertyChanged(nameof(Address));
			}
		}
	}
}