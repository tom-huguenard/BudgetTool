using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BaseClasses.POCOs.TransactionType;
using static BaseClasses.POCOs.AccountType;

namespace BudgetTests.When.NewAccountIs.CheckingAccount
{
    [TestClass]

    public class BalanceShouldBe :TestBase
    {
        [TestMethod]
        public void ZeroIfNoTransactions()
        {
            PortfolioManager.CreateAccount(Checking);
            Assert.AreEqual(0, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today));
        }

        [TestMethod]
        public void ZeroBeforeOpenDate()
        {
            PortfolioManager.CreateAccount(Checking);
            Assert.AreEqual(0, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today.AddDays(-3)));
        }
        [TestMethod]
        public void TenAfterTenDollarDeposit()
        {
            PortfolioManager.CreateAccount(Checking, UsefulStartDate);
            AddCompletedTransaction(10, ManualDeposit, 1);
            Assert.AreEqual(10, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today));
        }

        [TestMethod]
        public void FortyThreeAfterFiveScheduledTenDollarDepositsAndFiveScheduledOneDollarPayments()
        {
            PortfolioManager.CreateAccount(Checking, UsefulStartDate);
            PortfolioManager.CreateAccount(DirectDepositor);
            PortfolioManager.CreateAccount();

            AddCompletedTransaction(2, OutgoingCheck, 1, 1, 3);
            AddScheduledMonthlyMutualTransaction(2, 1, 10, DirectDeposit);
            AddScheduledMonthlyMutualTransaction(1, 3, 1, DirectDeposit);

            Assert.AreEqual(43, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today.AddMonths(5)));
        }
    }
}
