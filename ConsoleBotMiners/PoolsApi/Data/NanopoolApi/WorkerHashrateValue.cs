using Newtonsoft.Json;

namespace NanopoolApi.Data
{
	public class WorkerHashrateValue : Data
	{
		private string _worker { get; set; }
		private float _hashrate { get; set; }

		[JsonProperty("worker")]
		public string Worker
		{
			get
			{
				return _worker;
			}

			set
			{
				if (_worker == value) return;

				_worker = value;
				OnPropertyChanged(nameof(Worker));
			}
		}

		[JsonProperty("hashrate")]
		public float Hashrate
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