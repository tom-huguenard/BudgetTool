using System;
using BudgetTool;
using BudgetTool.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BudgetTool.Pocos.AccountType;

namespace BudgetTests
{
    [TestClass]
    public class BasicAccountTests :TestBase
    {
        
        private void VerifyAccount(int acctId, AccountType t = Bill, decimal balance = 0)
        {
            Assert.AreEqual(1, acctId);
            var acct = PortfolioManager.GetAccountById(acctId);
            Assert.AreEqual(t, acct.AccountType);
            Assert.AreEqual(balance, acct.OpeningBalance);
        }


        [TestMethod]
        public void CanCreateTwoCreditAccounts()
        {
            var acct = PortfolioManager.CreateAccount(Credit);
            VerifyAccount(acct, Credit);
            acct = PortfolioManager.CreateAccount(Credit);
            Assert.AreEqual(2, acct);
        }

        [TestMethod]
        public void CanCreateCreditAccount()
        {
            var acct = PortfolioManager.CreateAccount(Credit);
            VerifyAccount(acct, Credit);
        }
        [TestMethod]
        public void CanCreateSavingsAccount()
        {
            var acct = PortfolioManager.CreateAccount(Savings);
            VerifyAccount(acct, Savings);
        }
        [TestMethod]
        public void CanCreateCheckingAccount()
        {
            var acct = PortfolioManager.CreateAccount(Checking);
            VerifyAccount(acct, Checking);
        }
        [TestMethod]
        public void CanCreateBillAccount()
        {
            var acct = PortfolioManager.CreateAccount();
            VerifyAccount(acct);
        }


    }
}
