using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class BlocksStats : Data
	{
		private int _date { get; set; }
		private float _difficulty { get; set; }
		private float _blockTime { get; set; }

		[JsonProperty("date")]
		public int Date {
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
		public float Difficulty {
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

		[JsonProperty("block_time")]
		public float BlockTime {
			get
			{
				return _blockTime;
			}

			set
			{
				if (_blockTime == value) return;

				_blockTime = value;
				OnPropertyChanged(nameof(BlockTime));
			}
		}
	}
}