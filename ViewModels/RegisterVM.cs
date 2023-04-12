using System.ComponentModel.DataAnnotations;
using DTS_Tugas6.Models;

namespace DTS_Tugas6.ViewModels;

public class RegisterVM
{
    // Nik
    [StringLength(5)]
    public string Nik { get; set; }

    // First Name
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    // Last Name
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    // Birth Date
    [Display(Name = "Birth Date")]
    public DateTime Birthdate { get; set; }

    // Gender
    public Gender Gender { get; set; }

    // Email
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; }

    // Phone
    [StringLength(20)]
    [Display(Name = "Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }

    // Major
    [StringLength(100)]
    public string Major { get; set; }

    // Degree
    [StringLength(10)]
    public string Degree { get; set; }

    // GPA
    [Range(0, 4, ErrorMessage = "The {0} cannot be less than {1} & greater than {2}")]
    public double GPA { get; set; }

    // University Name
    [StringLength(100)]
    [Display(Name = "University Name")]
    public string UniversityName { get; set; }

    // Password
    [StringLength(16)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    // Confirm Password
    [StringLength(16)]
    [DataType(DataType.Password), Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}