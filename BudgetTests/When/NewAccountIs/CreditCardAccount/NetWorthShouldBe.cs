using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BaseClasses.POCOs.TransactionType;
using static BaseClasses.POCOs.AccountType;

namespace BudgetTests.When.NewAccountIs.CreditCardAccount
{
    [TestClass]
    public class NetWorthShouldBe : TestBase
    {

        [TestMethod]
        public void TenAfterTenDollarPayment()
        {
            PortfolioManager.CreateAccount(Credit, UsefulStartDate);
            AddCompletedTransaction(10, ElectronicPayment, 1);
            var result = PortfolioManager.GetNetWorthByDate(1, DateTime.Today);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TwentyAfterTwoMonthlyScheduledTenDollarPayments()
        {
            PortfolioManager.CreateAccount(Credit);
            AddScheduledTransaction(10, ElectronicPayment);
            Assert.AreEqual(20, PortfolioManager.GetNetWorth(DateTime.Today.AddMonths(2)));
            Assert.AreEqual(20, PortfolioManager.GetNetWorthByDate(1, DateTime.Today.AddMonths(2)));
        }

        [TestMethod]
        public void TwentyAfterTwoDailyScheduledTenDollarPayments()
        {
            PortfolioManager.CreateAccount(Credit);
            AddScheduledTransaction(10, ElectronicPayment, 1, null);
            Assert.AreEqual(20, PortfolioManager.GetNetWorth(DateTime.Today.AddDays(2)));
            Assert.AreEqual(20, PortfolioManager.GetNetWorthByDate(1, DateTime.Today.AddDays(2)));
        }

    }
}
