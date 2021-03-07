using Newtonsoft.Json;
using PoolsSelector.Data.NanopoolApi;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
    public class Payments : Response
	{
		[JsonProperty("data")]
		public List<Payment> Data { get; set; }

		public Payments()
		{
			Data = new List<Payment>();
		}
	}
}