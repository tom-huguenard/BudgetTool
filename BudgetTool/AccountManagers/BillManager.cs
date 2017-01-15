using System;
using BudgetTool.Pocos;

namespace BudgetTool.AccountManagers
{
    public class BillManager : AccountManagerBase
    {
        public override decimal GetAccountBalanceByDate(DateTime date)
        {
            return 0;
        }

        public override decimal GetNetWorthByDate(DateTime date)
        {
            return 0;
        }
    }
}