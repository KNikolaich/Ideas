using Newtonsoft.Json;

namespace PoolsApi.Response
{
	public class IntValue : NanopoolApi.Response.Response
	{
		private int _data { get; set; }

		[JsonProperty("data")]
		public int Data
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