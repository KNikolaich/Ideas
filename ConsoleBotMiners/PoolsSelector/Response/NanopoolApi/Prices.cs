using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
	public class Prices : Response
	{
		private Prices _data { get; set; }

		[JsonProperty("data")]
		public Prices Data
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