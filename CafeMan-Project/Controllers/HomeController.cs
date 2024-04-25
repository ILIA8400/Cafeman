using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Cafe> cafeRepo;

        public HomeController(IRepository<Cafe> cafeRepo)
        {
            this.cafeRepo = cafeRepo;
        }

        public IActionResult Index()
        {
            var cafes = cafeRepo.GetAll();
            return View(cafes);
        }

    }
}
