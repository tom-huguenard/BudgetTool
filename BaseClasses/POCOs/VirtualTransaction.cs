using System;

namespace BaseClasses.POCOs
{
    public class VirtualTransaction
    {
        public long TransactionId { get; set; }
        public long? ScheduledTransactionId { get; set; }
        public int? OtherAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionTypeId { get; set; }
        public string Comment { get; set; }
        public bool IsActual { get; set; }
        public bool IsPending { get; set; }

    }
}