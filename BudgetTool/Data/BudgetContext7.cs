using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using BudgetTool.Data.Pocos;

namespace BudgetTool.Data
{
    public class BudgetConfiguration : DbConfiguration
    {
        public BudgetConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory("Server=tcp:budgetserver.database.windows.net,1433;Database=BudgetDB;User ID=BudgetTom@budgetserver;Password=microsoft20350!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
    public class BudgetContext7 : DbContext
    {
        public BudgetContext7() 
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CompletedTransaction> CompletedTransactions { get; set; }
        public DbSet<MasterAccount> MasterAccounts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

    }
}
