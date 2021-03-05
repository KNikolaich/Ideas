using Newtonsoft.Json;

namespace PoolsApi.Response
{
	public class FloatValue : NanopoolApi.Response.Response
	{
		private float _data { get; set; }

		[JsonProperty("data")]
		public float Data
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