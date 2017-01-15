using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class ScheduledTransaction : IScheduledTransaction
    {
        public int PortfolioId { get; set; }
        [Key]
        public long ScheduledTransactionId { get; set; }
        public int? SourceAccountId { get; set; }
        public int? DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DayOfMonth { get; set; }
        public int? DaysPerCycle { get; set; }
        public int? MonthsPerCycle { get; set; }
        public int TransactionTypeId { get; set; }
        [MaxLength(100)]
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public virtual IPortfolio Portfolio { get; set; }
        [ForeignKey("SourceAccountId")]
        public virtual IAccount SourceAccount { get; set; }
        [ForeignKey("DestinationAccountId")]
        public virtual IAccount DestinationAccount { get; set; }
    }
}