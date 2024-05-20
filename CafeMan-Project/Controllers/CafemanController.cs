using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
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


        
        public IActionResult Cafeman(string id)
        {
            ViewBag.Title = "کافه من";
            var model = new CafemanVM()
            {
                ID =id
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Cafeman(CafemanVM model)
        {
            if (ModelState.IsValid)
            {
                var cafe = new Cafe()
                {
                    CafeName = model.CafeName,
                    CafeDescription = model.CafeDescription,
                    Tel = model.Tel,
                    Address = model.Address,
                    Website = model.Website,
                    Location = model.Location,
                    PriceRange = model.PriceRange,
                    Details = model.Details,
                };

                await cafeRepo.Insert(cafe);

                HttpContext.Response.Cookies.Append("usi", model.ID);

                return RedirectToAction("HomeAccount", "Home");
            }

            return View(model);
        }
    }
}
