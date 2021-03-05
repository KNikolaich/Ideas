using Newtonsoft.Json;
using System.Collections.Generic;

namespace NanopoolApi.Response
{
	public class ShareRateHistory : Response
	{
		[JsonProperty("data")]
		public List<Data.ShareRateHistory> Data { get; set; }

		public ShareRateHistory()
		{
			Data = new List<Data.ShareRateHistory>();
		}
	}
}