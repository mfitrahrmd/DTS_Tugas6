using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_Tugas6.Models;

[Table("TB_M_Roles")]
public class Role
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }
    
    public ICollection<AccountRole>? AccountsRoles { get; set; }
}