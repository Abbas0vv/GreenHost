using GreenHost.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GreenHost.Controllers;

public class HomeController : Controller
{
    private readonly TeamMemberRepository _teamMemberRepository;

    public HomeController(TeamMemberRepository teamMemberRepository)
    {
        _teamMemberRepository = teamMemberRepository;
    }

    public IActionResult Index()
    {
        var members = _teamMemberRepository.GetAll();
        return View(members);
    }
}
