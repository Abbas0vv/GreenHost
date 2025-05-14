using GreenHost.Database.Models;
using GreenHost.Database.ViewModels;
using GreenHost.Helpers.Extentions;

namespace GreenHost.Database.Repositories;

public class TeamMemberRepository
{
    private readonly GreenHostDbContext _context;
    private readonly IWebHostEnvironment _environment;
    private const string FOLDER_NAME = "Uploads/TeamMember";

    public TeamMemberRepository(GreenHostDbContext context, IWebHostEnvironment environment = null)
    {
        _context = context;
        _environment = environment;
    }

    public List<TeamMember> GetAll()
    {
        return _context.TeamMembers.Take(4).OrderBy(t => t.Id).ToList();
    }

    public TeamMember GetById(int? id)
    {
        return _context.TeamMembers.FirstOrDefault(t => t.Id == id);
    }

    public void Insert(TeamMemberViewModel memberVm)
    {
        if (memberVm.File is not null && !memberVm.File.IsValidFile()) return;

        var member = new TeamMember()
        {
            Name = memberVm.Name,
            Surname = memberVm.Surname,
            Description = memberVm.Description,
            ImageUrl = memberVm.File.CreateFile(_environment.WebRootPath, FOLDER_NAME)
        };

        _context.TeamMembers.Add(member);
        _context.SaveChanges();
    }

    public void Update(int? id, TeamMemberViewModel memberVm)
    {
        var member = GetById(id);
        if (member is null) return;

        member.Name = memberVm.Name;
        member.Surname = memberVm.Surname;
        member.Description = memberVm.Description;

        if (memberVm.File is not null && memberVm.File.IsValidFile())
            member.ImageUrl = memberVm.File.UpdateFile(_environment.WebRootPath, FOLDER_NAME, member.ImageUrl);

        _context.SaveChanges();
    }

    public void Delete(int? id)
    {
        var member = GetById(id);
        if (member is not null)
        {
            _context.Remove(member);
            _context.SaveChanges();
        }

    }
}
