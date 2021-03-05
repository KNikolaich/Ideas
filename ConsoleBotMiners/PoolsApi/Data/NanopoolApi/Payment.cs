using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class Payment : Data
	{
		private int _date { get; set; }
		private string _txHash { get; set; }
		private float _amount { get; set; }
		private bool _confirmed { get; set; }

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

		[JsonProperty("txHash")]
		public string TxHash
		{
			get
			{
				return _txHash;
			}

			set
			{
				if (_txHash == value) return;

				_txHash = value;
				OnPropertyChanged(nameof(TxHash));
			}
		}

		[JsonProperty("amount")]
		public float Amount
		{
			get
			{
				return _amount;
			}

			set
			{
				if (_amount == value) return;

				_amount = value;
				OnPropertyChanged(nameof(Amount));
			}
		}

		[JsonProperty("confirmed")]
		public bool Confirmed
		{
			get
			{
				return _confirmed;
			}

			set
			{
				if (_confirmed == value) return;

				_confirmed = value;
				OnPropertyChanged(nameof(Confirmed));
			}
		}
	}
}