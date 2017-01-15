using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class CompletedTransaction : ICompletedTransaction

    { 
        public int PortfolioId { get; set; }
        [Key]
        public long TransactionId { get; set; }
        public long? ScheduledTransactionId { get; set; }
        public int? SourceAccountId { get; set; }
        public int? DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionTypeId { get; set; }
        [MaxLength(100)]
        public string Comment { get; set; }
        public bool IsPending { get; set; }
        public virtual IPortfolio Portfolio { get; set; }
        [ForeignKey("SourceAccountId")]
        public virtual IAccount SourceAccount { get; set; }
        [ForeignKey("DestinationAccountId")]
        public virtual IAccount DestinationAccount { get; set; }
        public virtual IScheduledTransaction ScheduledTransaction { get; set; }
    }
}