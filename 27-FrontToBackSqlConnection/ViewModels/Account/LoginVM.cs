using System.ComponentModel.DataAnnotations;

namespace FrontToBackSqlConnection.ViewModels;

public class LoginVM
{
    [MaxLength(50)]
    [MinLength(5)]
    public string UsernameOrEmail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool IsPersitent { get; set; }
}