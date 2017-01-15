using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;
using BaseClasses.POCOs;

namespace BudgetTool.Data.Pocos
{
    public class Account : IAccount
    {
        [Index("IX_AccountName", 1, IsUnique = true)]
        public int PortfolioId { get; set; }
        [Key]
        public int AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public decimal OpeningBalance { get; set; }
        [Index("IX_AccountName", 2, IsUnique = true)]
        [MaxLength(100)]
        public string AccountName { get; set; }
        [MaxLength(100)]
        public string AccountNumber { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime? DateAccountClosed { get; set; }
        public int MonthlyDueDom { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MonthlyNonPrinciple { get; set; }
        public decimal CollateralValue { get; set; }
        public bool IsActive { get; set; }
        public virtual IPortfolio Portfolio { get; set; }

    }
}