using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class SignInController : Controller
    {
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            
            return View();
        }
    }
}
