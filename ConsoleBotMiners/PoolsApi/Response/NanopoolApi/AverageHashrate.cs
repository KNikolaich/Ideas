using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class AverageHashrate : Response
	{
		private Data.AverageHashrate _data { get; set; }

		[JsonProperty("data")]
		public Data.AverageHashrate Data
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