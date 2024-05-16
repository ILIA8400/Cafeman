using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SignUpController(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(AddUserViewModel model)
        {

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            if (!await roleManager.RoleExistsAsync("Cafe owner"))
                await roleManager.CreateAsync(new IdentityRole("Cafe owner"));



            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"User");

                    string userId = user.Id;

                    HttpContext.Response.Cookies.Append("usi", userId, new CookieOptions()
                    {
                        Path = "/Home/HomeAccount",
                    });

                    return RedirectToAction("HomeAccount", "Home");
                }
                    
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
               
            }

            return View(model);
        }
    }
}
