using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class WorkersAverageHashrate : Response
	{
		private Data.WorkersAverageHashrate _data { get; set; }

		[JsonProperty("data")]
		public Data.WorkersAverageHashrate Data
		{
			get
			{
				return _data;
			}

			set
			{
				if (_data == value) return;

				_data = value;
				OnPropertyChanged(nameof(Data));
			}
		}
	}
}