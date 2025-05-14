using GreenHost.Database;
using GreenHost.Database.Models.Account;
using GreenHost.Database.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid) return View(registerModel);

            AppUser user = new AppUser()
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                Email = registerModel.Email,
                UserName = registerModel.Username
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(registerModel);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null) return NotFound();

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            if (!result.Succeeded) return View(loginModel);


            return RedirectToAction("Index", "Home");
        }
    }
}
