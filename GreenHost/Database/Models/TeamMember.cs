using System.ComponentModel.DataAnnotations;

namespace GreenHost.Database.Models;

public class TeamMember : BaseEntity
{
    [MinLength(3)]
    public string Name { get; set; }
    [MinLength(3)]
    public string Surname { get; set; }
    [MinLength(5)]
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
}
