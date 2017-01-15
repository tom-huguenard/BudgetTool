using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Pocos
{
    public class MasterAccount
    {
        [Key]
        public int MasterAccountId { get; set; }
        [Index("IX_MasterAccountName", 1, IsUnique = true)]
        [MaxLength(100)]
        public string  MasterAccountName { get; set; }
    }
}
