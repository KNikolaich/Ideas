using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
    public class BlocksStats : Response
	{
		[JsonProperty("data")]
		public List<Data.NanopoolApi.BlocksStats> Data { get; set; }

		public BlocksStats()
		{
			Data = new List<Data.NanopoolApi.BlocksStats>();
		}
	}
}