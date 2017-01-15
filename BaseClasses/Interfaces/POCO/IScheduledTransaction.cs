using System;

namespace BaseClasses.Interfaces.POCO
{
    public interface IScheduledTransaction
    {
        decimal Amount { get; set; }
        string Comment { get; set; }
        int? DayOfMonth { get; set; }
        int? DaysPerCycle { get; set; }
        IAccount DestinationAccount { get; set; }
        int? DestinationAccountId { get; set; }
        DateTime? EndDate { get; set; }
        bool IsActive { get; set; }
        int? MonthsPerCycle { get; set; }
        IPortfolio Portfolio { get; set; }
        int PortfolioId { get; set; }
        long ScheduledTransactionId { get; set; }
        IAccount SourceAccount { get; set; }
        int? SourceAccountId { get; set; }
        DateTime StartDate { get; set; }
        int TransactionTypeId { get; set; }
    }
}