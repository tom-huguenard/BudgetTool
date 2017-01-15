using System;
using BaseClasses.POCOs;

namespace BaseClasses.Interfaces.POCO
{
    public interface IAccount
    {
        int AccountId { get; set; }
        string AccountName { get; set; }
        string AccountNumber { get; set; }
        AccountType AccountType { get; set; }
        decimal CollateralValue { get; set; }
        decimal CreditLimit { get; set; }
        DateTime? DateAccountClosed { get; set; }
        DateTime DateAccountOpened { get; set; }
        decimal InterestRate { get; set; }
        bool IsActive { get; set; }
        int MonthlyDueDom { get; set; }
        decimal MonthlyNonPrinciple { get; set; }
        decimal OpeningBalance { get; set; }
        string PhoneNumber { get; set; }
        IPortfolio Portfolio { get; set; }
        int PortfolioId { get; set; }
    }
}