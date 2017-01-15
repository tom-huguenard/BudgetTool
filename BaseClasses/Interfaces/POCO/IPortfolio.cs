namespace BaseClasses.Interfaces.POCO
{
    public interface IPortfolio
    {
        bool IsActive { get; set; }
        IMasterAccount MasterAccount { get; set; }
        int MasterAccountId { get; set; }
        int PortfolioId { get; set; }
        string PortfolioName { get; set; }
    }
}