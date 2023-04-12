using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DTS_Tugas6.Models;

[Table("TB_M_Accounts")]
public class Account
{
    [Column(TypeName = "char(5)")]
    [Key, ForeignKey(nameof(Models.Employee))]
    public string EmployeeNik { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Password { get; set; }
    
    public virtual Employee? Employee { get; set; }
    
    public virtual ICollection<AccountRole>? AccountRoles { get; set; }
}