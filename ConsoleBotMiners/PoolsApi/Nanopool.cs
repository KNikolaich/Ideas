using NanopoolApi.Response;
using Newtonsoft.Json;
using System;
using System.Net;
using PoolsApi;
using PoolsApi.Data;
using PoolsApi.Response;

namespace NanopoolApi
{
	public class Nanopool : PoolApiBase
	{
		private NanopoolStatics.PoolType Type { get; set; }
		
        public Nanopool(NanopoolStatics.PoolType type, WebProxy proxy = null) : base(proxy)
		{
			Type = type;
		}

        protected override string ValidAndRestyleUrl<T>(string url)
        {
            url = base.ValidAndRestyleUrl<T>(url);
            return url.Replace(NanopoolStatics.PoolTypeHolder, Enum.GetName(typeof(NanopoolStatics.PoolType), Type).ToLower());
        }

        protected override FloatValue GetAccountBalance(string account)
		{
			
			var result = LoadResponse<FloatValue>(string.Format(NanopoolStatics.AccountBalance, account) );
			return result;
		}

        protected override FloatValue GetCurrentHashrate(string account, string worker = null)
        {
            
            var result = LoadResponse<FloatValue>(string.Format(NanopoolStatics.CurrentHashrate, account, worker.UrlPart()));
			
            return result;
        }

        protected override float GetAverageHashrate(string account, DurationTimeEnum duration = DurationTimeEnum.h24, string worker = null)
		{
			var response = LoadResponse<AverageHashrate>(string.Format(NanopoolStatics.AverageHashrate, account, worker.UrlPart()));

            var result = 0f;
            switch (duration)
            {
				case DurationTimeEnum.h1:
                    result = response.Data.H1;
					break;

                case DurationTimeEnum.h3:
                    result = response.Data.H3;
					break;

                case DurationTimeEnum.h6:
                    result = response.Data.H6;
					break;

                case DurationTimeEnum.h12:
                    result = response.Data.H12;
					break;

                case DurationTimeEnum.h24:
                    result = response.Data.H24;
					break;
			}
			return result;
		}

		public FloatValue GetAverageHashrateLimited(string account, int hours, string worker = null)
		{
			
			var result = LoadResponse<FloatValue>(string.Format(NanopoolStatics.AverageHashrateLimited, account, worker.UrlPart(), hours));

			return result;
		}

		public ChartData GetChartData(string account, string worker = null)
		{
			
			var result = LoadResponse<ChartData>(string.Format(NanopoolStatics.ChartData, account, worker.UrlPart()));

			return result;
		}

		public StringValue GetCheckMinerAccount(string account)
		{
			
			var result = LoadResponse<StringValue>(string.Format(NanopoolStatics.CheckMinerAccount, account));

			return result;
		}

		public GeneralInfo GetGeneralInfo(string account)
		{
			
			var result = LoadResponse<GeneralInfo>(string.Format(NanopoolStatics.GeneralInfo, account));

			return result;
		}

		public HashrateHistory GetHashrateHistory(string account, string worker = null)
		{
			
			var result = LoadResponse<HashrateHistory>(string.Format(NanopoolStatics.HashrateHistory, account, worker.UrlPart()));

			return result;
		}

		public HashrateAndBalance GetHashrateAndBalance(string account)
		{
			var result = LoadResponse<HashrateAndBalance>(string.Format(NanopoolStatics.HashrateAndBalance, account));

			return result;
		}

		public IntValue GetLastReportedHashrateForAccount(string account, string worker = null)
		{
			
			var result = LoadResponse<IntValue>(string.Format(NanopoolStatics.LastReportedHashrateForAccount, account, worker.UrlPart()));

			return result;
		}

		public ListOfWorkers GetListOfWorkers(string account)
		{
			
			var result = LoadResponse<ListOfWorkers>(string.Format(NanopoolStatics.ListOfWorkers, account));

			return result;
		}

		public Payments GetPayments(string account)
		{
			
			var result = LoadResponse<Payments>(string.Format(NanopoolStatics.Payments, account));

			return result;
		}

		public ShareRateHistory GetShareRateHistory(string account, string worker = null)
		{
			
			var result = LoadResponse<ShareRateHistory>(string.Format(NanopoolStatics.ShareRateHistory, account, worker.UrlPart()));

			return result;
		}

		public WorkersAverageHashrate GetWorkersAverageHashrate(string account)
		{
			
			var result = LoadResponse<WorkersAverageHashrate>(string.Format(NanopoolStatics.WorkersAverageHashrate, account));

			return result;
		}

		public WorkersHashrate GetWorkersAverageHashrateLimited(string account, int hours)
		{
			
			var result = LoadResponse<WorkersHashrate>(string.Format(NanopoolStatics.WorkersAverageHashrateLimited, account, hours));

			return result;
		}

		public WorkersHashrate GetWorkersLastReportedHashrate(string account)
		{
			
			var result = LoadResponse<WorkersHashrate>(string.Format(NanopoolStatics.WorkersLastReportedHashrate, account));

			return result;
		}

		public FloatValue GetAverageBlockTime()
		{
			
			var result = LoadResponse<FloatValue>(NanopoolStatics.AverageBlockTime);

			return result;
		}

		public BlocksStats GetBlocksStats(int offset, int count)
		{
			
			var result = LoadResponse<BlocksStats>(string.Format(NanopoolStatics.BlocksStats, offset, count));

			return result;
		}

		public Blocks GetBlocks(int offset, int count)
		{
			
			var result = LoadResponse<Blocks>(string.Format(NanopoolStatics.Blocks, offset, count));

			return result;
		}

		public IntValue GetLastBlockNumber()
		{
			
			var result = LoadResponse<IntValue>(NanopoolStatics.LastBlockNumber);

			return result;
		}

		public IntValue GetTimeToNextEpoch()
		{
			
			var result = LoadResponse<IntValue>(NanopoolStatics.TimeToNextEpoch);

			return result;
		}

		public Calculator GetCalculator(int hashrate)
		{
			
			var result = LoadResponse<Calculator>(string.Format(NanopoolStatics.Calculator, hashrate));

			return result;
		}

		public Prices GetPrices()
		{
			
			var result = LoadResponse<Prices>(NanopoolStatics.Prices);

			return result;
		}

		public IntValue GetNumberOfMiners()
		{
			
			var result = LoadResponse<IntValue>(NanopoolStatics.NumberOfMiners);

			return result;
		}

		public IntValue GetNumberOfWorkers()
		{
			
			var result = LoadResponse<IntValue>(NanopoolStatics.NumberOfWorkers);

			return result;
		}

		public IntValue GetPoolHashrate()
		{
			var result = LoadResponse<IntValue>(NanopoolStatics.PoolHashrate);

			return result;
		}

		public TopMiners GetTopMiners()
		{
			var result = LoadResponse<TopMiners>(NanopoolStatics.TopMiners);

			return result;
		}

	}
}