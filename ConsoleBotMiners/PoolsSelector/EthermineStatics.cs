
using PoolsSelector.Data;

namespace PoolsSelector
{
    public static class EthermineStatics
    {
        private static string walletFake = "<<wallet>>";
        private static string UrlBase = "https://api.ethermine.org/";
        private static string UrlMiner = $"{UrlBase}miner/{walletFake}/";

        public static string GetUrl(string ownWallet, RequestMethodEnum requestMethodEnum)
        {
            switch (requestMethodEnum)
            {
                case RequestMethodEnum.currentHashrate:
                case RequestMethodEnum.averageHashrate:
                case RequestMethodEnum.unpaid:
                    return UrlMiner.Replace(walletFake, ownWallet) + "currentStats";
            }

            return UrlMiner;
        }
    }
}
