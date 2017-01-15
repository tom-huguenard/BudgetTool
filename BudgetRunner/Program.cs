using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetTool.Data;
using BudgetTool.Pocos;

namespace BudgetRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BudgetContext7())
            {
                var ma = new MasterAccount {MasterAccountName = "!23"};
                db.MasterAccounts.Add(ma);
                var portfolio = new Portfolio {PortfolioName = "Bob", MasterAccount = ma};
                db.Portfolios.Add(portfolio);
                var account = new Account { AccountName = "Bob", DateAccountOpened = DateTime.Now, Portfolio = portfolio};
                db.Accounts.Add(account);
                db.SaveChanges();


            }
        }
    }
}
