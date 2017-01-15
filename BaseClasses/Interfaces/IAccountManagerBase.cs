using System;
using BaseClasses.Interfaces.POCO;

namespace BaseClasses.Interfaces
{
    public interface IAccountManagerBase
    {
        IAccount CurrentAccount { get; set; }
        IPortfolioManager pm { get; set; }

        decimal GetAccountBalanceByDate(DateTime date);
        decimal GetNetWorthByDate(DateTime date);
    }
}