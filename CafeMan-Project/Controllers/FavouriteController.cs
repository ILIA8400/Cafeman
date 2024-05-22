using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    [Authorize("Roles")]
    public class FavouriteController : Controller
    {
        private readonly CafemanDbContext ctx;
        private readonly UserManager<User> userManager;

        public FavouriteController(CafemanDbContext ctx,UserManager<User> userManager)
        {
            this.ctx = ctx;
            this.userManager = userManager;
        }

        [Route("Favourite/List")]
        public async Task<IActionResult> Favourite()
        {
            ViewBag.Title = "علاقه مندی ها";

            User user;
            if(TempData.Peek("userId") != null)
                user = await userManager.FindByIdAsync(TempData.Peek("userId").ToString());
            else
                return RedirectToAction("SignIn", "SignIn");


            return View(user);
        }
    }
}
