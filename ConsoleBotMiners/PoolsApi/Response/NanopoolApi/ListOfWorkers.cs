using NanopoolApi.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
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