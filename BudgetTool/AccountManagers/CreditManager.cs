using System;
using System.Linq;
using BudgetTool.Pocos;
using static BudgetTool.Pocos.TransactionType;

namespace BudgetTool.AccountManagers
{
    public class CreditManager : AccountManagerBase
    {
        private decimal Interest => (decimal)(1.0 + ((double)CurrentAccount.InterestRate) / 1200);

        public override decimal GetNetWorthByDate(DateTime date)
        {
            return CurrentAccount.CollateralValue - GetAccountBalanceByDate(date);
        }

        public override decimal GetAccountBalanceByDate(DateTime date)
        {
            var balance = CurrentAccount.OpeningBalance;

            GetTransactionsByDate(date)
                .OrderBy(x => x.TransactionDate)
                .ToList()
                .ForEach(x => balance = ApplyTransaction(x.TransactionTypeId, balance, x.Amount));

            return balance;
        }

        private decimal ApplyTransaction(int transactionTypeId, decimal balance, decimal amount)
        {
            var tt = (TransactionType) transactionTypeId;
            switch (tt)
            {
                case Reconciliation:
                case CreditCardPurchase:
                    return balance + amount;
                case ElectronicPayment:
                case OutgoingCheck:
                    balance = Math.Round(balance * Interest, 2);
                    balance += CurrentAccount.MonthlyNonPrinciple - amount;
                    return balance;
                default:
                    return balance + amount;
            }

        }
    }
}