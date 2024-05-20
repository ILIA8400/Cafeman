using CafeMan_Project.Infra;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CafeMan_Project.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public SignInController(SignInManager<User> signInManager,UserManager<User> userManager) 
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [Route("SignIn")]
        public IActionResult SignIn()
        {
            ViewBag.Title = "ورود";
            return View();
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Pass, true, false);
                if (result.Succeeded)
                {
                    
                    var user = await userManager.FindByEmailAsync(model.Email);
                    var userId = user?.Id.ToString();

                    HttpContext.Response.Cookies.Append("usi",userId, new CookieOptions()
                    {
                        Path = "/Home/HomeAccount",
                    });

                    
                    return RedirectToAction("HomeAccount","Home");
                }

            }

            return View(model);
        }

    }
}
