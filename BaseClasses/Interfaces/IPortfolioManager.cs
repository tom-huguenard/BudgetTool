using System;
using System.Collections.Generic;
using BaseClasses.Interfaces.POCO;
using BaseClasses.POCOs;

namespace BaseClasses.Interfaces
{
    public interface IPortfolioManager
    {
        IAccountManagerFactory AccountManagerFactory { get; set; }
        List<IAccount> Accounts { get; set; }
        List<ICompletedTransaction> CompletedTransactions { get; set; }
        List<IScheduledTransaction> ScheduledTransactions { get; set; }

        int CreateAccount(AccountType at = AccountType.Bill, DateTime? dateOpened = default(DateTime?));
        decimal GetAccountBalanceByDate(int accountId, DateTime date);
        IAccount GetAccountById(int accountId);
        decimal GetNetWorth(DateTime date);
        decimal GetNetWorthByDate(int accountId, DateTime date);
        long GetNextTransactionId();
        void RealizeScheduledTransactions();
    }
}