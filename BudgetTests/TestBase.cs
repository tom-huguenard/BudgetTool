using System;
using System.Collections.Generic;
using System.Linq;
using BaseClasses.Interfaces.POCO;
using BaseClasses.POCOs;
using BudgetTool;
using BudgetTool.Data.Pocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BudgetTests
{
    [TestClass]
    public class TestBase
    {
        protected DateTime UsefulStartDate { get; set; }
        public PortfolioManager PortfolioManager { get; set; }
        public TestBase()
        {

            UsefulStartDate = new DateTime(2016,1,1);
        }

        [TestInitialize]
        public void Init()
        {
            PortfolioManager = new PortfolioManager(new Portfolio
            {
                IsActive = true,
                MasterAccountId = 1,
                PortfolioId = 1,
                PortfolioName = "Test"
            });
            PortfolioManager.Accounts = new List<IAccount>();
            PortfolioManager.ScheduledTransactions = new List<IScheduledTransaction>();
            PortfolioManager.CompletedTransactions = new List<ICompletedTransaction>();
        }

        protected  void AddScheduledTransaction(decimal amount, TransactionType tt, int? daysPerCycle = null, int? monthsPerCycle = 1, DateTime? endDate = null)
        {
            PortfolioManager.ScheduledTransactions.Add(new ScheduledTransaction
            {
                Amount = amount,
                DestinationAccountId = 1,
                SourceAccountId = GetOtherAccount(tt),
                ScheduledTransactionId = PortfolioManager.ScheduledTransactions.Count + 1,
                TransactionTypeId = (int)tt,
                Comment = "Test",
                StartDate = DateTime.Today.AddDays(1),
                EndDate = null,
                DaysPerCycle = daysPerCycle,
                MonthsPerCycle = monthsPerCycle,
                IsActive = true
            });
        }

        protected  void AddCompletedTransaction(decimal amount, TransactionType tt, int daysAfterAccountOpened = 0, int? sourceId = null, int destinationId = 1, bool isPending = false)
        {
            var acct = PortfolioManager.GetAccountById(destinationId);

            PortfolioManager.CompletedTransactions.Add(new CompletedTransaction
            {
                Amount = amount,
                DestinationAccountId = destinationId,
                SourceAccountId = sourceId,
                TransactionTypeId = (int)tt,
                Comment = "Test",
                TransactionDate = acct.DateAccountOpened.AddDays(daysAfterAccountOpened),
                IsPending = isPending,
                TransactionId = PortfolioManager.GetNextTransactionId()
            });
        }

        protected  void AddScheduledMonthlyMutualTransaction(int sourceId, int destinationId, decimal amount, TransactionType tt)
        {
            PortfolioManager.ScheduledTransactions.Add(new ScheduledTransaction
            {
                Amount = amount,
                DestinationAccountId = destinationId,
                SourceAccountId = sourceId,
                ScheduledTransactionId = PortfolioManager.ScheduledTransactions.Count + 1,
                TransactionTypeId = (int)tt,
                Comment = "Test",
                StartDate = DateTime.Today.AddDays(1),
                EndDate = null,
                DaysPerCycle = null,
                MonthsPerCycle = 1,
                IsActive = true
            });
        }


        private  int? GetOtherAccount(TransactionType tt)
        {
            return PortfolioManager
                    .Accounts
                    .Where(x => x.AccountType == AccountType.DirectDepositor && tt == TransactionType.DirectDeposit)
                    .Select(x => x.AccountId)
                    .FirstOrDefault();
        }
    }
}