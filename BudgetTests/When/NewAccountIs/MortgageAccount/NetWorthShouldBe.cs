using System;
using BaseClasses.POCOs;
using BudgetTool.Data.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetTests.When.NewAccountIs.MortgageAccount
{
    [TestClass]
    public class NetWorthShouldBe : TestBase
    {


        [TestMethod]
        public void NetWorthOfNewMortgageAccountAfterTwoMonthlyScheduledPaymentsIsCorrect()
        {
            PortfolioManager.CreateAccount(AccountType.Credit, DateTime.Today);
            var mort = PortfolioManager.GetAccountById(1);
            mort.OpeningBalance = 100000;
            mort.InterestRate = 5;
            mort.CollateralValue = 100000;
            mort.MonthlyNonPrinciple = 200;

            PortfolioManager.CreateAccount(AccountType.Checking, DateTime.Today);
            var chk = PortfolioManager.GetAccountById(2);
            chk.OpeningBalance = 10000;

            Assert.AreEqual(10000, PortfolioManager.GetNetWorth(DateTime.Today));

            AddScheduledMonthlyMutualTransaction(2, 1, 1000, TransactionType.ElectronicPayment);

            Assert.AreEqual(8000, PortfolioManager.GetNetWorthByDate(2, DateTime.Today.AddMonths(2)));
            Assert.AreEqual(new decimal(768.26), PortfolioManager.GetNetWorthByDate(1, DateTime.Today.AddMonths(2)));

            Assert.AreEqual(new decimal(8768.26), PortfolioManager.GetNetWorth(DateTime.Today.AddMonths(2)));
        }

    }
}
