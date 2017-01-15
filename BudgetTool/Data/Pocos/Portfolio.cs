using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class Portfolio : IPortfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        [Index("IX_PortfolioPerMasterAccount", 1, IsUnique = true)]

        public int MasterAccountId { get; set; }
        public bool IsActive { get; set; }
        [Index("IX_PortfolioPerMasterAccount", 2, IsUnique = true)]
        [MaxLength(100)]
        public string PortfolioName { get; set; }
        public virtual IMasterAccount MasterAccount { get; set; }
    }
}
