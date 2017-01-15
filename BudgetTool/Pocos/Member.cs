using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Pocos
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Index("IX_UserPerMasterAccount", 1, IsUnique = true)]
        public int MasterAccountId { get; set; }
        [Index("IX_UserPerMasterAccount", 2, IsUnique = true)]
        public int UserId { get; set; }
        public bool CanWrite { get; set; }
        public bool IsOwner { get; set; }
        public virtual MasterAccount MasterAccount { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
