using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class SearchApiController : Controller
    {
        private readonly ICafeRepository<Cafe> cafeRepo;

        public SearchApiController(ICafeRepository<Cafe> cafeRepo)
        {
            this.cafeRepo = cafeRepo;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var cafes = await cafeRepo.GetAll();
            var result = cafes.Where(c => c.CafeName.Contains(name)).ToList();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Cafe not found");
            }
        }
    }
}
