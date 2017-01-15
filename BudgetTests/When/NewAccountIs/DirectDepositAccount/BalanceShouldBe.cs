using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetTests.When.NewAccountIs.DirectDepositAccount
{
    [TestClass]

    public class BalanceShouldBe :TestBase
    {
        [TestMethod]
        public void Zero()
        {
            PortfolioManager.CreateAccount();
            Assert.AreEqual(0, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today));
        }
    }
}
