using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class Prices : Data
	{
		private float _btc { get; set; }
		private float _usd { get; set; }
		private float _eur { get; set; }
		private float _rur { get; set; }
		private float _cny { get; set; }

		[JsonProperty("price_btc")]
		public float Btc
		{
			get
			{
				return _btc;
			}

			set
			{
				if (_btc == value) return;

				_btc = value;
				OnPropertyChanged(nameof(Btc));
			}
		}

		[JsonProperty("price_usd")]
		public float Usd
		{
			get
			{
				return _usd;
			}

			set
			{
				if (_usd == value) return;

				_usd = value;
				OnPropertyChanged(nameof(Usd));
			}
		}

		[JsonProperty("price_eur")]
		public float Eur
		{
			get
			{
				return _eur;
			}

			set
			{
				if (_eur == value) return;

				_eur = value;
				OnPropertyChanged(nameof(Eur));
			}
		}

		[JsonProperty("price_rur")]
		public float Rur
		{
			get
			{
				return _rur;
			}

			set
			{
				if (_rur == value) return;

				_rur = value;
				OnPropertyChanged(nameof(Rur));
			}
		}

		[JsonProperty("price_cny")]
		public float Cny
		{
			get
			{
				return _cny;
			}

			set
			{
				if (_cny == value) return;

				_cny = value;
				OnPropertyChanged(nameof(Cny));
			}
		}
	}
}