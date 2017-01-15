using System;
using BaseClasses.POCOs;
using BudgetTool.Data.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetTests.When.NewAccountIs.BillAccount
{
    [TestClass]
    public class NetWorthShouldBe : TestBase
    {

        [TestMethod]
        public void Zero()
        {
            PortfolioManager.CreateAccount(AccountType.Bill, UsefulStartDate);
            var result = PortfolioManager.GetNetWorthByDate(1, DateTime.Today);
            Assert.AreEqual(0, result);
        }


    }
}
