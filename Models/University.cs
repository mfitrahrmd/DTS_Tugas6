using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_Tugas6.Models;

[Table("TB_M_Universities")]
public class University
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    
    public virtual ICollection<Education>? Educations { get; set; }
}