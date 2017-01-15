using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTool.Pocos
{
    public class UserAccount
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
