namespace PoolsApi
{
	public static class NanopoolStatics
	{
		public static readonly string PoolTypeHolder = "<<POOLTYPE>>";
		private static readonly string BaseApiUrl = $"https://api.nanopool.org/v1/{PoolTypeHolder}/";

		//Miners
		public static readonly string AccountBalance = BaseApiUrl + "balance/{0}"; //address

		public static readonly string AverageHashrate = BaseApiUrl + "avghashrate/{0}{1}"; //address, (optional worker)
		public static readonly string AverageHashrateLimited = BaseApiUrl + "avghashratelimited/{0}/{1}{2}"; //address, (optional worker), hours
		public static readonly string ChartData = BaseApiUrl + "hashratechart/{0}{1}"; //address, (optional worker)
		public static readonly string CheckMinerAccount = BaseApiUrl + "accountexist/{0}"; //address
		public static readonly string CurrentHashrate = BaseApiUrl + "hashrate/{0}{1}"; //address, (optional worker)
		public static readonly string GeneralInfo = BaseApiUrl + "user/{0}"; //address
		public static readonly string HashrateHistory = BaseApiUrl + "history/{0}{1}"; //address, (optional worker)
		public static readonly string HashrateAndBalance = BaseApiUrl + "balance_hashrate/{0}"; //address
		public static readonly string LastReportedHashrateForAccount = BaseApiUrl + "reportedhashrate/{0}{1}"; //address, (optional worker)
		public static readonly string ListOfWorkers = BaseApiUrl + "workers/{0}"; //address
		public static readonly string Payments = BaseApiUrl + "payments/{0}"; //address
		public static readonly string ShareRateHistory = BaseApiUrl + "shareratehistory/{0}{1}"; //address, (optional worker)
		public static readonly string WorkersAverageHashrate = BaseApiUrl + "avghashrateworkers/{0}"; //address
		public static readonly string WorkersAverageHashrateLimited = BaseApiUrl + "avghashrateworkers/{0}/{1}"; //address, hours
		public static readonly string WorkersLastReportedHashrate = BaseApiUrl + "reportedhashrates/{0}"; //address

		//Network
		public static readonly string AverageBlockTime = BaseApiUrl + "network/avgblocktime";

		public static readonly string BlocksStats = BaseApiUrl + "block_stats/{0}/{1}"; //offset, count
		public static readonly string Blocks = BaseApiUrl + "blocks/{0}/{1}"; //offset, count
		public static readonly string LastBlockNumber = BaseApiUrl + "network/lastblocknumber";
		public static readonly string TimeToNextEpoch = BaseApiUrl + "network/timetonextepoch";

		//Other
		public static readonly string Calculator = BaseApiUrl + "approximated_earnings/{0}"; //hashrate

		public static readonly string Prices = BaseApiUrl + "prices";

		//Pool
		public static readonly string NumberOfMiners = BaseApiUrl + "pool/activeminers";

		public static readonly string NumberOfWorkers = BaseApiUrl + "pool/activeworkers";
		public static readonly string PoolHashrate = BaseApiUrl + "pool/hashrate";
		public static readonly string TopMiners = BaseApiUrl + "pool/topminers";

		public enum PoolType
		{
			XMR = 1,
			ETH,
			ETC,
			SIA,
			ZEC,
			PASC,
			ETN
		}

		public static string UrlPart(this string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				return $"{value}/";
			}

			return "";
		}
	}
}