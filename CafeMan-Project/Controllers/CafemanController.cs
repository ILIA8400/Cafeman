using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class CafemanController : Controller
    {
        [Route("Cafeman/AddCafe")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
