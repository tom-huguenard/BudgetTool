using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClasses.Interfaces;
using BaseClasses.Interfaces.POCO;
using BudgetTool.Data.Pocos;

namespace BudgetTool.AccountManagers
{
    public class AccountManagerFactory : IAccountManagerFactory
    {
        public IPortfolioManager PortfolioManager { get; set; }

        public AccountManagerFactory(IPortfolioManager pm)
        {
            PortfolioManager = pm;
        }

        public IAccountManagerBase GetAccountManager<T>(IAccount acct) where T : IAccountManagerBase, new()
        {
            return new T { CurrentAccount = acct, pm = PortfolioManager };
        }
    }
}
