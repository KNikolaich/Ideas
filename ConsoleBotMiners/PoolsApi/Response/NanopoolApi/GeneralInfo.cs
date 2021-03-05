using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class GeneralInfo : Response
	{
		private Data.GeneralInfo _data { get; set; }

		[JsonProperty("data")]
		public Data.GeneralInfo Data
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