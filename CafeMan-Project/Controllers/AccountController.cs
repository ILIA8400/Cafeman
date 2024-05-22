using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return RedirectToAction("SignIn", "SignIn");
        }

        public IActionResult Login()
        {
            return RedirectToAction("SignIn", "SignIn");
        }
    }
}
