using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
	public class TopMiners : Response
	{
		[JsonProperty("data")]
		public List<TopMiners> Data { get; set; }

		public TopMiners()
		{
			Data = new List<TopMiners>();
		}
	}
}