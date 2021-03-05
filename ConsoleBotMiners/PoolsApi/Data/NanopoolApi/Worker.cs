using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class Worker : Data
	{
		private float _h1 { get; set; }
		private float _h3 { get; set; }
		private float _h6 { get; set; }
		private float _h12 { get; set; }
		private float _h24 { get; set; }
		private string _id { get; set; }
		private int _uid { get; set; }
		private string _hashrate { get; set; }
		private int _lastShare { get; set; }
		private int _rating { get; set; }

		[JsonProperty("h1")]
		public float H1
		{
			get
			{
				return _h1;
			}

			set
			{
				if (_h1 == value) return;

				_h1 = value;
				OnPropertyChanged(nameof(H1));
			}
		}

		[JsonProperty("h3")]
		public float H3
		{
			get
			{
				return _h3;
			}

			set
			{
				if (_h3 == value) return;

				_h3 = value;
				OnPropertyChanged(nameof(H3));
			}
		}

		[JsonProperty("h6")]
		public float H6
		{
			get
			{
				return _h6;
			}

			set
			{
				if (_h6 == value) return;

				_h6 = value;
				OnPropertyChanged(nameof(H6));
			}
		}

		[JsonProperty("h12")]
		public float H12
		{
			get
			{
				return _h12;
			}

			set
			{
				if (_h12 == value) return;

				_h12 = value;
				OnPropertyChanged(nameof(H12));
			}
		}

		[JsonProperty("h24")]
		public float H24
		{
			get
			{
				return _h24;
			}

			set
			{
				if (_h24 == value) return;

				_h24 = value;
				OnPropertyChanged(nameof(H24));
			}
		}

		[JsonProperty("id")]
		public string Id
		{
			get
			{
				return _id;
			}

			set
			{
				if (_id == value) return;

				_id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		[JsonProperty("uid")]
		public int Uid
		{
			get
			{
				return _uid;
			}

			set
			{
				if (_uid == value) return;

				_uid = value;
				OnPropertyChanged(nameof(Uid));
			}
		}

		[JsonProperty("hashrate")]
		public string Hashrate
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

		[JsonProperty("lastshare")]
		public int LastShare
		{
			get
			{
				return _lastShare;
			}

			set
			{
				if (_lastShare == value) return;

				_lastShare = value;
				OnPropertyChanged(nameof(LastShare));
			}
		}

		[JsonProperty("rating")]
		public int Rating
		{
			get
			{
				return _rating;
			}

			set
			{
				if (_rating == value) return;

				_rating = value;
				OnPropertyChanged(nameof(Rating));
			}
		}

		public void UpdateOther(Worker current)
		{
			current.H1 = H1;
			current.H3 = H3;
			current.H6 = H6;
			current.H12 = H12;
			current.H24 = H24;
			current.Hashrate = Hashrate;
			current.LastShare = LastShare;
			current.Rating = Rating;
		}
	}
}