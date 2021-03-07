using Newtonsoft.Json;
using PoolsSelector.Data.NanopoolApi;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
	public class ListOfWorkers : Response
	{
		[JsonProperty("data")]
		public List<Worker> Data { get; set; }

		public ListOfWorkers()
		{
			Data = new List<Worker>();
		}
	}
}