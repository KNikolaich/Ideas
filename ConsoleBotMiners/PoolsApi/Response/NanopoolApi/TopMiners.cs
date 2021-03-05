using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
{
	public class TopMiners : Response
	{
		[JsonProperty("data")]
		public List<Data.TopMiners> Data { get; set; }

		public TopMiners()
		{
			Data = new List<Data.TopMiners>();
		}
	}
}