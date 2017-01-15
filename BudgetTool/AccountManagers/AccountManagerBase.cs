using System;
using System.Collections.Generic;
using System.Linq;
using BaseClasses.Interfaces;
using BaseClasses.Interfaces.POCO;
using BaseClasses.POCOs;
using BudgetTool.Data.Pocos;
using VirtualTransaction = BudgetTool.Data.Pocos.VirtualTransaction;

namespace BudgetTool.AccountManagers
{
    public class AccountManagerBase : IAccountManagerBase
    {
        private readonly ScheduledTransactionManager _scheduledTransactionManager = new ScheduledTransactionManager();
        public IAccount CurrentAccount { get; set; }
        public IPortfolioManager pm { get; set; }


        protected List<VirtualTransaction> GetTransactionsByDate(DateTime date)
        {

            var rtn = new List<VirtualTransaction>();

            rtn.AddRange(CompletedTransactionManager.GetTransactions(pm, CurrentAccount.AccountId, date, true, tran => tran.DestinationAccountId, tran => tran.SourceAccountId));
            rtn.AddRange(CompletedTransactionManager.GetTransactions(pm, CurrentAccount.AccountId, date, false, tran => tran.SourceAccountId, tran => tran.DestinationAccountId));

            rtn.AddRange(ScheduledTransactionManager.GetTransactions(pm, CurrentAccount.AccountId, date, true, tran => tran.DestinationAccountId, tran => tran.SourceAccountId));
            rtn.AddRange(ScheduledTransactionManager.GetTransactions(pm, CurrentAccount.AccountId, date, false, tran => tran.SourceAccountId, tran => tran.DestinationAccountId));
            return rtn;

        }

        

        protected virtual decimal TotalOfTransactionsThroughDate(DateTime date)
        {
            var trans = GetTransactionsByDate(date);
            return trans.Sum(x => x.Amount);
        }
        public virtual decimal GetAccountBalanceByDate(DateTime date)
        {
            if (date < CurrentAccount.DateAccountOpened) return 0;
            return CurrentAccount.OpeningBalance + TotalOfTransactionsThroughDate(date);
        }

        public virtual decimal GetNetWorthByDate(DateTime date)
        {
            var rtn = GetAccountBalanceByDate(date);
            return Sign(CurrentAccount.AccountType) * rtn;
        }

        private decimal Sign(AccountType accountType)
        {
            return accountType == AccountType.Credit ? -1 : 1;
        }
        

    }
}