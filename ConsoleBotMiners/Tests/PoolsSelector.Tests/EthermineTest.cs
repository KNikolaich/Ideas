using System;
using Xunit;

namespace PoolsSelector.Tests
{
    public class EthermineTest
    {

        [Fact]
        public void GetSomeUrlResult_ethermineAccountBalance_ResultDoesntEmpty()
        {
            var target = new PoolsSelector.Ethermine("0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var accountBalance = target.GetAccountBalance();
            Assert.NotEqual(accountBalance, 0f);
        }

        [Fact]
        public void GetSomeUrlResult_ethermineCurrentHashrate_ResultDoesntEmpty()
        {
            var target = new PoolsSelector.Ethermine("0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var currentHr = target.GetCurrentHashrate();
            Assert.NotEqual(currentHr, 0f);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
