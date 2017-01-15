using BaseClasses.Interfaces.POCO;

namespace BaseClasses.Interfaces
{
    public interface IAccountManagerFactory
    {
        IPortfolioManager PortfolioManager { get; set; }

        IAccountManagerBase GetAccountManager<T>(IAccount acct) where T : IAccountManagerBase, new();
    }
}