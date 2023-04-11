using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_Tugas6.Models;

[Table("TB_M_Educations")]
public class Education
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string Major { get; set; }
    
    [Column(TypeName = "varchar(10)")]
    public string Degree { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public double GPA { get; set; }
    
    [ForeignKey(nameof(Models.University))]
    public int UniversityId { get; set; }
    
    public University University { get; set; }
    
    public Profiling Profiling { get; set; }
}