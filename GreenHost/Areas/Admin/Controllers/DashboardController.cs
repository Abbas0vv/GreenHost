using GreenHost.Database.Repositories;
using GreenHost.Database.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GreenHost.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly TeamMemberRepository _teamMemberRepository;

        public DashboardController(TeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public IActionResult Index()
        {
            var members = _teamMemberRepository.GetAll();
            return View(members);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TeamMemberViewModel memberVm)
        {
            if(!ModelState.IsValid) return View(memberVm);
            _teamMemberRepository.Insert(memberVm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            var memberModel = _teamMemberRepository.GetById(id);
            var memberVm = new TeamMemberViewModel()
            {
                Name = memberModel.Name,
                Surname = memberModel.Surname,
                Description = memberModel.Description
            };
            return View(memberVm);
        }

        [HttpPost]
        public IActionResult Update(int? id, TeamMemberViewModel memberVm)
        {
            if (!ModelState.IsValid) return View(memberVm);
            _teamMemberRepository.Update(id, memberVm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _teamMemberRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
