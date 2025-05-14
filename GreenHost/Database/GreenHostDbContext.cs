using GreenHost.Database.Models;
using GreenHost.Database.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenHost.Database;

public class GreenHostDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public GreenHostDbContext(DbContextOptions options) : base(options) { }


    public DbSet<TeamMember> TeamMembers { get; set; }
}
