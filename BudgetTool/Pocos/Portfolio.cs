using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Pocos
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        [Index("IX_PortfolioPerMasterAccount", 1, IsUnique = true)]

        public int MasterAccountId { get; set; }
        public bool IsActive { get; set; }
        [Index("IX_PortfolioPerMasterAccount", 2, IsUnique = true)]
        [MaxLength(100)]
        public string PortfolioName { get; set; }
        public virtual MasterAccount MasterAccount { get; set; }
    }
}
