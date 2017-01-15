using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTool.Pocos
{
    public class ScheduledTransaction
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
        public virtual Portfolio Portfolio { get; set; }
        [ForeignKey("SourceAccountId")]
        public virtual Account SourceAccount { get; set; }
        [ForeignKey("DestinationAccountId")]
        public virtual Account DestinationAccount { get; set; }
    }
}