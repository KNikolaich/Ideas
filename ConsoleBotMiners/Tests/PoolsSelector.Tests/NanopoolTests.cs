using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PoolsSelector.Tests
{
    public class NanopoolTests
    {
        [Fact]
        public void GetSomeUrlResult_EthAccountBalance_ResultDoesntEmpty()
        {
            var target = new PoolsSelector.Nanopool(NanopoolStatics.PoolType.ETH, "0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var accountBalance = target.GetAccountBalance();
            Assert.NotEqual(0f, accountBalance);
        }


        [Fact]
        public void GetSomeUrlResult_EthCurrentHashrate_ResultDoesntEmpty()
        {
            var target = new PoolsSelector.Nanopool(NanopoolStatics.PoolType.ETH, "0x85cFc2bBb112De8c36401F61041D14b2B97b66c0");
            var currentHr = target.GetAverageHashrate();
            Assert.NotEqual(0f, currentHr);
        }
    }
}
