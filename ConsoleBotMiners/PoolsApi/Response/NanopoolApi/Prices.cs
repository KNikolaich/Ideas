using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class Prices : Response
	{
		private Data.Prices _data { get; set; }

		[JsonProperty("data")]
		public Data.Prices Data
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