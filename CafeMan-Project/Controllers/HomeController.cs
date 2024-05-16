using CafeMan_Project.Filters;
using CafeMan_Project.Infra;
using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICafeRepository<Cafe> cafeRepo;
        private readonly UserManager<User> userManager;      

        public HomeController(ICafeRepository<Cafe> cafeRepo,UserManager<User> userManager)
        {
            this.cafeRepo = cafeRepo;
            this.userManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            var cafes = await cafeRepo.GetAll();
            return View(cafes);
        }



        //[Authorize(Roles ="User")]
        public async Task<IActionResult> HomeAccount()
        {
            var userId = HttpContext.Request.Cookies["usi"];

            var cafes = await cafeRepo.GetAll();
            var user = await userManager.FindByIdAsync(userId);
            
            var model = new HomeAccountVM()
            {
                Cofes = cafes,
                User = user
            };

            HttpContext.Response.Cookies.Delete("usi");

            if(user == null)
                return BadRequest(ModelState);
            else
                return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SearchResult([Bind("User", "SearchName")] HomeAccountVM model)
        {
            var cafes = await cafeRepo.GetOwnerCafe();
            var result = cafes.Where(c => c.CafeName.Contains(model.SearchName)).ToList();


            if (result.Any())
            {
                var vm = new HomeAccountVM()
                {
                    Cofes = cafes,
                    User = model.User,
                    SearchName = model.SearchName,
                    
                    ResultSearch = result
                };

                return View(vm);
            }
            else
            {
                var vm = new HomeAccountVM()
                {
                    Cofes = cafes,
                    User = model.User,
                    SearchName = model.SearchName,
                    
                    ResultSearch = "کافه ای با این نام وجود ندارد"
                };

                return View(vm);
            }
        }
    }
}
