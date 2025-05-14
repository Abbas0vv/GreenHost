namespace GreenHost.Database.ViewModels;

public class TeamMemberViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Description { get; set; }
    public IFormFile? File { get; set; }
}
