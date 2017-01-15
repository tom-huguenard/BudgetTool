using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class MasterAccount : IMasterAccount
    {
        [Key]
        public int MasterAccountId { get; set; }
        [Index("IX_MasterAccountName", 1, IsUnique = true)]
        [MaxLength(100)]
        public string  MasterAccountName { get; set; }
    }
}
