using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClientPool.Tests
{
    [TestClass]
    public class JustGettingTest
    {
        [TestMethod]
        public void GetSomeUrlResult_ethermineCurrentStats_ResultDoesntEmpty()
        {
            var strUrl = "https://api.ethermine.org/miner/0x85cFc2bBb112De8c36401F61041D14b2B97b66c0/currentStats";
            var target = JustGetter.GetSomeUrlResult(strUrl);
            Assert.IsFalse(String.IsNullOrEmpty(target));
        }

        [TestMethod]
        public void GetSomeUrlResult_ethermineCurrentStats_ResultHasCurrentHashrate()
        {
            var strUrl = "https://api.ethermine.org/miner/0x85cFc2bBb112De8c36401F61041D14b2B97b66c0/currentStats";
            var target = JustGetter.GetValueFromRequiest<decimal>(strUrl, "currentHashrate");
            Assert.IsFalse(target == 0);
        }
    }
}
