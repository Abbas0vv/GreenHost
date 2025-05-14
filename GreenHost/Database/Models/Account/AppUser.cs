using Microsoft.AspNetCore.Identity;

namespace GreenHost.Database.Models.Account;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
