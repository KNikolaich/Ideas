using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoolsSelector.Response.NanopoolApi
{
	public class ShareRateHistory : Response
	{
		[JsonProperty("data")]
		public List<ShareRateHistory> Data { get; set; }

		public ShareRateHistory()
		{
			Data = new List<ShareRateHistory>();
		}
	}
}