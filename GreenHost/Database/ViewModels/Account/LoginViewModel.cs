using System.ComponentModel.DataAnnotations;

namespace GreenHost.Database.ViewModels.Account;

public class LoginViewModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    [Required]
    public string Password { get; set; }
}
