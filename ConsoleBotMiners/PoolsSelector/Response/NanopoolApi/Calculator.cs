using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
    public class Calculator : Response
	{
		private Data.NanopoolApi.Calculator _data { get; set; }

		[JsonProperty("data")]
		public Data.NanopoolApi.Calculator Data
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