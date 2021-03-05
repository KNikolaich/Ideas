using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PoolsApi.Tests
{
    [TestClass]
    public class EthermineTest
    {
        [TestMethod]
        public void GetSomeUrlResult_ethermineAccountBalance_ResultDoesntEmpty()
        {
            var target = new PoolsApi.Ethermine("0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var accountBalance = target.GetAccountBalance();
            Assert.AreNotEqual(accountBalance, 0f);
        }

        [TestMethod]
        public void GetSomeUrlResult_ethermineCurrentHashrate_ResultDoesntEmpty()
        {
            var target = new PoolsApi.Ethermine("0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var currentHr = target.GetCurrentHashrate();
            Assert.AreNotEqual(currentHr, 0f);
        }
    }
}
