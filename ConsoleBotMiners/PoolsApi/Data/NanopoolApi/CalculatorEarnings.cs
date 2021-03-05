using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class CalculatorEarnings : Data
	{
		private float _coins { get; set; }
		private float _dollars { get; set; }
		private float _yuan { get; set; }
		private float _euros { get; set; }
		private float _rubles { get; set; }
		private float _bitcoins { get; set; }

		[JsonProperty("coins")]
		public float Coins
		{
			get
			{
				return _coins;
			}

			set
			{
				if (_coins == value) return;

				_coins = value;
				OnPropertyChanged(nameof(Coins));
			}
		}

		[JsonProperty("dollars")]
		public float Dollars
		{
			get
			{
				return _dollars;
			}

			set
			{
				if (_dollars == value) return;

				_dollars = value;
				OnPropertyChanged(nameof(Dollars));
			}
		}

		[JsonProperty("yuan")]
		public float Yuan
		{
			get
			{
				return _yuan;
			}

			set
			{
				if (_yuan == value) return;

				_yuan = value;
				OnPropertyChanged(nameof(Yuan));
			}
		}

		[JsonProperty("euros")]
		public float Euros
		{
			get
			{
				return _euros;
			}

			set
			{
				if (_euros == value) return;

				_euros = value;
				OnPropertyChanged(nameof(Euros));
			}
		}

		[JsonProperty("rubles")]
		public float Rubles
		{
			get
			{
				return _rubles;
			}

			set
			{
				if (_rubles == value) return;

				_rubles = value;
				OnPropertyChanged(nameof(Rubles));
			}
		}

		[JsonProperty("bitcoins")]
		public float Bitcoins
		{
			get
			{
				return _bitcoins;
			}

			set
			{
				if (_bitcoins == value) return;

				_bitcoins = value;
				OnPropertyChanged(nameof(Bitcoins));
			}
		}
	}
}