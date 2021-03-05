using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class Calculator : Response
	{
		private Data.Calculator _data { get; set; }

		[JsonProperty("data")]
		public Data.Calculator Data
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