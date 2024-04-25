using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class SignUpController : Controller
    {
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
