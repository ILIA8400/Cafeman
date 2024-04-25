using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class FavouriteController : Controller
    {
        [Route("Favourite/FavouriteList")]
        public IActionResult Favourite()
        {
            return View();
        }
    }
}
