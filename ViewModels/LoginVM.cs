using System.ComponentModel.DataAnnotations;

namespace DTS_Tugas6.ViewModels;

public class LoginVM
{
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}