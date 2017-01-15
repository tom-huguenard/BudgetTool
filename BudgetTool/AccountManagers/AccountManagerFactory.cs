using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTool.Pocos;

namespace BudgetTool.AccountManagers
{
    public class AccountManagerFactory
    {
        public PortfolioManager PortfolioManager { get; set; }

        public AccountManagerFactory(PortfolioManager pm)
        {
            PortfolioManager = pm;
        }
        public  AccountManagerBase GetAccountManager<T>(Account acct) where T:AccountManagerBase, new()
        {
            return new T {CurrentAccount = acct, pm = PortfolioManager};
        }

    }
}
