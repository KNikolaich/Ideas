using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
{
	public class ChartData : Response
	{
		[JsonProperty("data")]
		public List<Data.ChartData> Data { get; set; }

		public ChartData()
		{
			Data = new List<Data.ChartData>();
		}
	}
}