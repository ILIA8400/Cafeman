using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class RankingController : Controller
    {
        private readonly IRepository<Cafe> cafe;

        public RankingController(IRepository<Cafe> cafe)
        {
            this.cafe = cafe;
        }
        [Route("Ranking/List")]
        public IActionResult Ranking()
        {
            var cafes = cafe.GetAll();//.OrderByDescending(c=>c.Star);
            
            return View(cafes);
        }
    }
}
