using NanopoolApi.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
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