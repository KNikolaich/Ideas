using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
{
	public class HashrateHistory : Response
	{
		[JsonProperty("data")]
		public List<Data.HashrateHistory> Data { get; set; }

		public HashrateHistory()
		{
			Data = new List<Data.HashrateHistory>();
		}
	}
}