using blet15.Models;
using blet15.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blet15.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AuthController : Controller
    {
        UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            this.roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) {
                return View(vm);
            }
            var email=await _userManager.FindByEmailAsync(vm.Email);
            if (email != null)
            {

                if (!await _userManager.IsInRoleAsync(email, "Admin"))
                {
                    ModelState.AddModelError("", "Bu səhifəyə yalnız admin daxil ola bilər");
                    return View(vm);
                }
                var result = await _signInManager.PasswordSignInAsync(email, vm.Password, false, false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Email ve ya Sifre sehvdir");
                    return View(vm);
                }

            return RedirectToAction("Index","Dashboard");
            }
            return View(vm);
        }
        
    
    }
}
