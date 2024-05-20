using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class RankingController : Controller
    {
        private readonly ICafeRepository<Cafe> cafe;

        public RankingController(ICafeRepository<Cafe> cafe)
        {
            this.cafe = cafe;
        }

        [Route("Ranking/List")]
        public async Task<IActionResult> Ranking()
        {
            ViewBag.Title = "رنکینگ";
            var cafes = await cafe.GetAll();//.OrderByDescending(c=>c.Star);
            
            return View(cafes);
        }
    }
}
