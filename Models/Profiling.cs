using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_Tugas6.Models;

[Table("TB_TR_Profilings")]
public class Profiling
{
    [Column(TypeName = "char(5)")]
    [Key, ForeignKey(nameof(Models.Employee))]
    public string EmployeeNik { get; set; }
 
    [ForeignKey(nameof(Models.Education))]
    public int EducationId { get; set; }
    
    public Education Education { get; set; }
    
    public Employee Employee { get; set; }
}