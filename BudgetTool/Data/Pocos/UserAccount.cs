using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseClasses.Interfaces.POCO;

namespace BudgetTool.Data.Pocos
{
    public class UserAccount : IUserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Index("IX_UserName", 1, IsUnique = true)]
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
