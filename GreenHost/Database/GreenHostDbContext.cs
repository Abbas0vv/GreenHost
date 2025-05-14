using GreenHost.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenHost.Database;

public class GreenHostDbContext : DbContext
{
    public GreenHostDbContext(DbContextOptions options) : base(options) { }


    public DbSet<TeamMember> TeamMembers { get; set; }
}
