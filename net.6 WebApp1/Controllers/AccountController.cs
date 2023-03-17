using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using net._6_WebApp1.Data;
using net._6_WebApp1.Models;
using net._6_WebApp1.ViewModels;

namespace net._6_WebApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);
            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credidentials. Try agane!";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credidentials. Please try again!";
            return View(loginViewModel);
        }
    }
}
