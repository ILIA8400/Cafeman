using CafeMan_Project.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{

    [Authorize(Policy = "Roles")]
    public class SignOutController : Controller
    {
        private readonly SignInManager<User> signInManager;

        public SignOutController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }


        [Route("SignOut")]
        public async Task<IActionResult> SignOutUser()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
