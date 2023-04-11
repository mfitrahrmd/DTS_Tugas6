using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_Tugas6.Models;

[Table("TB_TR_Account_Roles")]
public class AccountRole
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "char(5)")]
    [ForeignKey(nameof(Account))]
    public string AccountNik { get; set; }
    
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    
    public Account? Account { get; set; }
    
    public Role? Role { get; set; }
}