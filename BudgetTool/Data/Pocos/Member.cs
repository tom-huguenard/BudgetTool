using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class Member : IMember
    {
        [Key]
        public int MemberId { get; set; }
        [Index("IX_UserPerMasterAccount", 1, IsUnique = true)]
        public int MasterAccountId { get; set; }
        [Index("IX_UserPerMasterAccount", 2, IsUnique = true)]
        public int UserId { get; set; }
        public bool CanWrite { get; set; }
        public bool IsOwner { get; set; }
        public virtual IMasterAccount MasterAccount { get; set; }
        public virtual IUserAccount UserAccount { get; set; }
    }
}
