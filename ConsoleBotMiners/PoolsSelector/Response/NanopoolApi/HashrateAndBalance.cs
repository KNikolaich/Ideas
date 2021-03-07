using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
    public class HashrateAndBalance : Response
	{
		private Data.NanopoolApi.HashrateAndBalance _data { get; set; }

		[JsonProperty("data")]
		public Data.NanopoolApi.HashrateAndBalance Data
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