using blet15.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blet15.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> SeedRoles()
        //{

        //    var roles = Enum.GetNames(typeof(Roles));
        //    foreach (var role in roles)
        //    {
        //        if (!await roleManager.RoleExistsAsync(role))
        //        {
        //            var result = await roleManager.CreateAsync(new IdentityRole(role));
        //        }
        //    }
        //    return Ok("Rollar Yaradildi");
        //}
    }
}
