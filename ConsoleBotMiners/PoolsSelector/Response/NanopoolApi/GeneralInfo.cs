using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
    public class GeneralInfo : Response
	{
		private Data.NanopoolApi.GeneralInfo _data { get; set; }

		[JsonProperty("data")]
		public Data.NanopoolApi.GeneralInfo Data
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