using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class CafemanController : Controller
    {
        private readonly ICafeRepository<Cafe> cafeRepo;

        public CafemanController(ICafeRepository<Cafe> cafeRepo)
        {
            this.cafeRepo = cafeRepo;
        }


        [Route("Cafeman/AddCafe")]
        public IActionResult Cafeman()
        {
            return View();
        }


        [HttpPost]
        [Route("Cafeman/AddCafe")]
        public IActionResult Cafeman(Cafe cafe)
        {
            if (ModelState.IsValid)
            {            
                cafeRepo.Insert(cafe);
                return RedirectToAction("Home","HomeAccount");
            }

            return View(cafe);
        }
    }
}
