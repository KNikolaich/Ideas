using Newtonsoft.Json;

namespace PoolsSelector.Response.NanopoolApi
{
	public class WorkersAverageHashrate : Response
	{
		private WorkersAverageHashrate _data { get; set; }

		[JsonProperty("data")]
		public WorkersAverageHashrate Data
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