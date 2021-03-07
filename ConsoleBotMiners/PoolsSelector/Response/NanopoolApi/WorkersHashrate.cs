using Newtonsoft.Json;
using PoolsSelector.Data.NanopoolApi;

namespace PoolsSelector.Response.NanopoolApi
{
	public class WorkersHashrate : Response
	{
		[JsonProperty("data")]
		public WorkerHashrateValue[] Data { get; set; }
	}
}