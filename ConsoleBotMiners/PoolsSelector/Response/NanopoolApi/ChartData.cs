using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
    public class ChartData : Response
	{
		[JsonProperty("data")]
		public List<Data.NanopoolApi.ChartData> Data { get; set; }

		public ChartData()
		{
			Data = new List<Data.NanopoolApi.ChartData>();
		}
	}
}