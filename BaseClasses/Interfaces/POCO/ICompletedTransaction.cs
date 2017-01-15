using System;

namespace BaseClasses.Interfaces.POCO
{
    public interface ICompletedTransaction
    {
        decimal Amount { get; set; }
        string Comment { get; set; }
        IAccount DestinationAccount { get; set; }
        int? DestinationAccountId { get; set; }
        bool IsPending { get; set; }
        IPortfolio Portfolio { get; set; }
        int PortfolioId { get; set; }
        IScheduledTransaction ScheduledTransaction { get; set; }
        long? ScheduledTransactionId { get; set; }
        IAccount SourceAccount { get; set; }
        int? SourceAccountId { get; set; }
        DateTime TransactionDate { get; set; }
        long TransactionId { get; set; }
        int TransactionTypeId { get; set; }
    }
}