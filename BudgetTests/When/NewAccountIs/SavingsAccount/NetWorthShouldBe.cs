using System;
using BudgetTool;
using BudgetTool.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BudgetTool.Pocos.AccountType;
using static BudgetTool.Pocos.TransactionType;

namespace BudgetTests.When.NewAccountIs.SavingsAccount
{
    [TestClass]
    public class NetWorthShouldBe : TestBase
    {

        [TestMethod]
        public void TenAfterTenDollarDeposit()
        {
            PortfolioManager.CreateAccount(Savings, UsefulStartDate);
            AddCompletedTransaction(10, ManualDeposit, 1);
            var result = PortfolioManager.GetNetWorthByDate(1, DateTime.Today);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TwentyAfterTwoMonthlyScheduledTenDollarDeposit()
        {
            PortfolioManager.CreateAccount(Savings);
            AddScheduledTransaction(10, DirectDeposit);
            Assert.AreEqual(20, PortfolioManager.GetNetWorth(DateTime.Today.AddMonths(2)));
            Assert.AreEqual(20, PortfolioManager.GetNetWorthByDate(1, DateTime.Today.AddMonths(2)));
        }

        [TestMethod]
        public void TwentyAfterTwoDailyScheduledTenDollarDeposit()
        {
            PortfolioManager.CreateAccount(Savings);
            AddScheduledTransaction(10, DirectDeposit, 1, null);
            Assert.AreEqual(20, PortfolioManager.GetNetWorth(DateTime.Today.AddDays(2)));
            Assert.AreEqual(20, PortfolioManager.GetNetWorthByDate(1, DateTime.Today.AddDays(2)));
        }

    }
}
