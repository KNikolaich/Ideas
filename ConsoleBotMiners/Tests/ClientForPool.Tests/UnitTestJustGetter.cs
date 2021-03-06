using System;
using Xunit;
using System.Net.Http;
using ClientPool;

namespace ClientForPool.Tests
{
    public class UnitTestJustGetter
    {

        public void Initialization()
        {

        }

        [Fact]
        public void GetSomeUrlResult_ethermineCurrentStats_ResultDoesntEmpty()
        {
            var strUrl = "https://api.ethermine.org/miner/0x85cFc2bBb112De8c36401F61041D14b2B97b66c0/currentStats";
            var target = JustGetter.GetSomeUrlResult(strUrl);
            Assert.False(String.IsNullOrEmpty(target));
        }
        
        [Fact]
        public void GetSomeUrlResult_ethermineCurrentStats_ResultHasCurrentHashrate()
        {
            var strUrl = "https://api.ethermine.org/miner/0x85cFc2bBb112De8c36401F61041D14b2B97b66c0/currentStats";
            var target = JustGetter.GetValueFromRequiest(strUrl, "CurrentHashrate");
            Assert.False(String.IsNullOrEmpty(target));
        }
    }
}
