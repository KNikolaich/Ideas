using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class Blocks : Data
	{
		private int _number { get; set; }
		private string _hash { get; set; }
		private int _date { get; set; }
		private long _difficulty { get; set; }
		private string _miner { get; set; }

		[JsonProperty("number")]
		public int Number
		{
			get
			{
				return _number;
			}

			set
			{
				if (_number == value) return;

				_number = value;
				OnPropertyChanged(nameof(Number));
			}
		}

		[JsonProperty("hash")]
		public string Hash
		{
			get
			{
				return _hash;
			}

			set
			{
				if (_hash == value) return;

				_hash = value;
				OnPropertyChanged(nameof(Hash));
			}
		}

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

		[JsonProperty("difficulty")]
		public long Difficulty
		{
			get
			{
				return _difficulty;
			}

			set
			{
				if (_difficulty == value) return;

				_difficulty = value;
				OnPropertyChanged(nameof(Difficulty));
			}
		}

		[JsonProperty("miner")]
		public string Miner
		{
			get
			{
				return _miner;
			}

			set
			{
				if (_miner == value) return;

				_miner = value;
				OnPropertyChanged(nameof(Miner));
			}
		}
	}
}