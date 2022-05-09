using System;
using NUnit.Framework;

namespace ConsoleBotMiners.Test
{
    public class MinersMonitorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddFinishData13_5Percent_FinishDateIs19_11_22()
        {
            var walletEth = new Wallet();
            walletEth.Limit = 0.05f;//', 'MiningStartTicks':'637848079800000000";
            walletEth.MiningStartTicks = 637848079800000000;

            var resStr = MinersMonitor.GetDateOfFinish(walletEth, 0.00701493f, new DateTime(2022, 05, 04, 11, 00, 00));
             
            Assert.IsTrue(resStr.Date == new DateTime(2022, 11, 19), "Сломалось вычисление даты окончания");
        }
    }
}