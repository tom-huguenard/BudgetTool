using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses.Interfaces;
using BaseClasses.Interfaces.POCO;
using BudgetTool.Data.Pocos;

namespace BudgetTool.AccountManagers
{
    public class CompletedTransactionManager
    {

        public static IEnumerable<VirtualTransaction> GetTransactions(IPortfolioManager mgr, int acctId, DateTime date, bool isCredit, Func<ICompletedTransaction, int?> thisAccount, Func<ICompletedTransaction, int?> otherAccount)
        {
            return mgr
                .CompletedTransactions
                .Where(x => thisAccount(x).HasValue && thisAccount(x) == acctId && x.TransactionDate <= date)
                .ToList()
                .Select(x => new VirtualTransaction
                {
                    Amount = isCredit ? x.Amount : -x.Amount,
                    IsActual = true,
                    ScheduledTransactionId = x.ScheduledTransactionId,
                    Comment = x.Comment,
                    TransactionId = x.TransactionId,
                    TransactionDate = x.TransactionDate,
                    IsPending = x.IsPending,
                    OtherAccountId = otherAccount(x),
                    TransactionTypeId = x.TransactionTypeId
                }).ToList();
        }

    }
}
