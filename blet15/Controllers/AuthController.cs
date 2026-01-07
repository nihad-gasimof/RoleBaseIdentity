using blet15.Models;
using blet15.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blet15.Controllers;

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

               
                var result = await _signInManager.PasswordSignInAsync(email, vm.Password, false, false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Email ve ya Sifre sehvdir");
                    return View(vm);
                }

            return RedirectToAction("Index","Home");
            }
            return View(vm);
        }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        var existuseremail = await _userManager.FindByEmailAsync(vm.Email);
        if (existuseremail != null)
        {
            ModelState.AddModelError("", "Bele user artiq var");
        }
        AppUser user = new AppUser()
        {
            UserName = vm.UserName,
            Email = vm.Email,
            
        };
        var result = await _userManager.CreateAsync(user, vm.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        await _userManager.AddToRoleAsync(user, "Member");
        return RedirectToAction("Index", "Home");

    }

}



