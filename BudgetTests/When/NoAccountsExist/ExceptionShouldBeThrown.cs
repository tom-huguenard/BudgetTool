using System;
using BudgetTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BudgetTests.When.NoAccountsExist
{
    [TestClass]
    public class ExceptionShouldBeThrown : TestBase
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenTryingToGetAccountById()
        {
            var a = PortfolioManager.GetAccountById(1);

        }
    }
}
