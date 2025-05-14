using Microsoft.AspNetCore.Mvc;

namespace GreenHost.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
