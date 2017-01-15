using System;
using System.Collections.Generic;
using System.Linq;
using BudgetTool.Pocos;

namespace BudgetTool.AccountManagers
{
    public class ScheduledTransactionManager
    {
        private static Func<DateTime, DateTime> NextDate { get; set; }

        private static IEnumerable<VirtualTransaction> ExpandScheduledItem(PortfolioManager pm, ScheduledTransaction scheduledTransaction, DateTime targetDate, bool isCredit, int? otherAccountId)
        {
            var rtn = new List<VirtualTransaction>();

            AssignNextDateDelegate(scheduledTransaction);

            for (var d = scheduledTransaction.StartDate; d <= targetDate; d = NextDate(d))
            {
                if (d > DateTime.Today)
                {
                    rtn.Add(new VirtualTransaction
                    {
                        Amount = isCredit ? scheduledTransaction.Amount : -scheduledTransaction.Amount,
                        IsActual = true,
                        ScheduledTransactionId = scheduledTransaction.ScheduledTransactionId,
                        Comment = scheduledTransaction.Comment,
                        TransactionId = 0,
                        TransactionDate = d,
                        IsPending = false,
                        OtherAccountId = otherAccountId,
                        TransactionTypeId = scheduledTransaction.TransactionTypeId
                    });
                }
            }
            return rtn;

        }
        public static IEnumerable<VirtualTransaction> GetTransactions(PortfolioManager pm, int accountId, DateTime date, bool isCredit, Func<ScheduledTransaction, int?> thisAccount, Func<ScheduledTransaction, int?> otherAccount)
        {
            var rtn = new List<VirtualTransaction>();

            pm.ScheduledTransactions
                .Where(x => thisAccount(x).HasValue && thisAccount(x) == accountId)
                .Where(x => x.IsActive)
                .ToList().ForEach(x => rtn.AddRange(ExpandScheduledItem(pm, x, date, isCredit, otherAccount(x))));
            
            return rtn;
        }

        public static void RealizeScheduledTransactions(PortfolioManager pm, ScheduledTransaction scheduledTransaction)
        { 
            if (!scheduledTransaction.IsActive) return;
            var already = pm.CompletedTransactions.Where(x => x.ScheduledTransactionId == scheduledTransaction.ScheduledTransactionId).ToList();

            AssignNextDateDelegate(scheduledTransaction);

            for (var d = scheduledTransaction.StartDate; d <= DateTime.Today; d = NextDate(d))
            {
                if (already.All(x => x.TransactionDate != d))
                {
                    pm.CompletedTransactions.Add(new CompletedTransaction
                    {
                        Amount = scheduledTransaction.Amount,
                        ScheduledTransactionId = scheduledTransaction.ScheduledTransactionId,
                        Comment = scheduledTransaction.Comment,
                        TransactionId = pm.GetNextTransactionId(),
                        TransactionDate = d,
                        IsPending = true,
                        SourceAccountId = scheduledTransaction.SourceAccountId,
                        DestinationAccountId = scheduledTransaction.DestinationAccountId,
                        TransactionTypeId = scheduledTransaction.TransactionTypeId
                    });
                }
            }




        }

        private static void AssignNextDateDelegate(ScheduledTransaction scheduledTransaction)
        {
            NextDate = null;
            if (scheduledTransaction.DaysPerCycle.HasValue)
                NextDate = (prevDate) => prevDate.AddDays(scheduledTransaction.DaysPerCycle.Value);
            if (scheduledTransaction.MonthsPerCycle.HasValue)
                NextDate = (prevDate) => prevDate.AddMonths(scheduledTransaction.MonthsPerCycle.Value);

            if (NextDate == null) throw new Exception("Scheduled Transaction without Date Rule");
        }
    }
}