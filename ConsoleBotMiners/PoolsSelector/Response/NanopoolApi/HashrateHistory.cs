using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
    public class HashrateHistory : Response
	{
		[JsonProperty("data")]
		public List<Data.NanopoolApi.HashrateHistory> Data { get; set; }

		public HashrateHistory()
		{
			Data = new List<Data.NanopoolApi.HashrateHistory>();
		}
	}
}