using System;
using BudgetTool;
using BudgetTool.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BudgetTool.Pocos.AccountType;
using static BudgetTool.Pocos.TransactionType;

namespace BudgetTests
{
    [TestClass]
    public class ScheduledTransactionTests :TestBase
    {
        [TestMethod]
        public void CanRealizeScheduledTransaction()
        {
            PortfolioManager.CreateAccount(Checking, UsefulStartDate);
            AddCompletedTransaction(10,TransactionType.DirectDeposit,1);
            PortfolioManager.CompletedTransactions[0].ScheduledTransactionId = 1;
            AddScheduledTransaction(10, TransactionType.DirectDeposit, 1, null);
            AddScheduledTransaction(10, TransactionType.DirectDeposit, 1, null);
            PortfolioManager.ScheduledTransactions[0].StartDate = UsefulStartDate.AddDays(1);
            PortfolioManager.ScheduledTransactions[1].IsActive = false;
            PortfolioManager.RealizeScheduledTransactions();
            Assert.AreEqual((DateTime.Today - UsefulStartDate).Days, PortfolioManager.CompletedTransactions.Count );

            Assert.AreEqual(10*(DateTime.Today - UsefulStartDate).Days,
                PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetScheduledTransactionsShouldThrowExceptionIfNoDateRule()
        {
            PortfolioManager.CreateAccount(Checking, UsefulStartDate);
            AddScheduledTransaction(10, CreditCardPurchase, null, null);
            Assert.AreEqual(10, PortfolioManager.GetAccountBalanceByDate(1, DateTime.Today));
        }

    }
}
