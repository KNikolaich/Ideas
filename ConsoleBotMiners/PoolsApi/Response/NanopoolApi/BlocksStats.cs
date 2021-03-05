using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
{
	public class BlocksStats : Response
	{
		[JsonProperty("data")]
		public List<Data.BlocksStats> Data { get; set; }

		public BlocksStats()
		{
			Data = new List<Data.BlocksStats>();
		}
	}
}