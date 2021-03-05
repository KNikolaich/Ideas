using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class HashrateAndBalance : Response
	{
		private Data.HashrateAndBalance _data { get; set; }

		[JsonProperty("data")]
		public Data.HashrateAndBalance Data
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