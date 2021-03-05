using Newtonsoft.Json;

namespace NanopoolApi.Response
{
	public class WorkersHashrate : Response
	{
		[JsonProperty("data")]
		public Data.WorkerHashrateValue[] Data { get; set; }
	}
}