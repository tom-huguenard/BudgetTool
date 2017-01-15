using System;
using System.Collections.Generic;
using System.Linq;
using BaseClasses.Interfaces;
using BaseClasses.Interfaces.POCO;
using BaseClasses.POCOs;
using BudgetTool.AccountManagers;
using BudgetTool.Data.Pocos;
using static BaseClasses.POCOs.TransactionType;
using static BaseClasses.POCOs.AccountType;


namespace BudgetTool
{
    public class PortfolioManager : IPortfolioManager
    {
        private Portfolio MyPortfolio { get; set; }
        private  Dictionary<AccountType, Func<IAccount, IAccountManagerBase>>  Managers { get; }
        public  List<IAccount> Accounts { get; set; }
        public  List<IScheduledTransaction> ScheduledTransactions { get; set; }
        public  List<ICompletedTransaction> CompletedTransactions { get; set; }
        public IAccountManagerFactory AccountManagerFactory { get; set; }

        public PortfolioManager(Portfolio portfolio)
        {
            MyPortfolio = portfolio;
            Accounts = new List<IAccount>();
            ScheduledTransactions = new List<IScheduledTransaction>();
            CompletedTransactions = new List<ICompletedTransaction>();
            AccountManagerFactory = new AccountManagerFactory(this);
            Managers = new Dictionary<AccountType, Func<IAccount,  IAccountManagerBase>>
            {
                [Bill] = AccountManagerFactory.GetAccountManager<BillManager>,
                [Credit] = AccountManagerFactory.GetAccountManager<CreditManager>,
                [Savings] = AccountManagerFactory.GetAccountManager<SavingsManager>,
                [Checking] = AccountManagerFactory.GetAccountManager<CheckingManager>,
                [DirectDepositor] = AccountManagerFactory.GetAccountManager<DirectDepositorManager>,
            };
        }

        public  decimal GetNetWorth(DateTime date)
        {
            decimal netWorth = 0;
            Accounts.ForEach(x => netWorth += GetNetWorthByDate(x.AccountId, date));
            return netWorth;
        }


        public  int CreateAccount(AccountType at = Bill, DateTime? dateOpened = null)
        {
            var acct = new Account
            {
                AccountType = at,
                OpeningBalance = 0,
                DateAccountOpened = dateOpened ?? DateTime.Today,
                AccountId = NextAccountId
            };
            Accounts.Add(acct);
            return acct.AccountId;
        }

        public  IAccount GetAccountById(int accountId)
        {
            var acct = Accounts.FirstOrDefault(x => x.AccountId == accountId);
            if (acct == null) throw new Exception("Account not found");
            return acct;
        }
        private  int NextAccountId
        {
            get { return !Accounts.Any() ? 1 : Accounts.Max(x => x.AccountId) + 1; }
        }

        public  decimal GetAccountBalanceByDate(int accountId, DateTime date)
        {
            var acct = GetAccountById(accountId);
            return Managers[acct.AccountType](acct).GetAccountBalanceByDate(date);
        }
        public  decimal GetNetWorthByDate(int accountId, DateTime date)
        {
            var acct = GetAccountById(accountId);
            return Managers[acct.AccountType](acct).GetNetWorthByDate(date);
        }


        public  void RealizeScheduledTransactions()
        {
            ScheduledTransactions
                .Where(x => x.IsActive)
                .ToList()
                .ForEach(x => ScheduledTransactionManager.RealizeScheduledTransactions(this, x));
        }

        public  long GetNextTransactionId()
        {
            if (CompletedTransactions.Any())
                return CompletedTransactions.Max(x => x.TransactionId) + 1;
            return 1;
        }
    }
}
