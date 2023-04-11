using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Models;

[
    Index(nameof(Email), IsUnique = true),
    Index(nameof(PhoneNumber), IsUnique = true)
]
[Table("TB_M_Employees")]
public class Employee
{
    [Column(TypeName = "char(5)")]
    [Key]
    public string Nik { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? LastName { get; set; }

    public DateTime Birthdate { get; set; }

    public Gender Gender { get; set; }

    public DateTime HiringDate { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? PhoneNumber { get; set; }
    
    public Profiling? Profiling { get; set; }
    
    public Account? Account { get; set; }
}

public enum Gender
{
    L,
    P
}