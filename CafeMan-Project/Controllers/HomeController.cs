using CafeMan_Project.Filters;
using CafeMan_Project.Infra;
using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Cafe> cafeRepo;
        private readonly IUserRepository<User> userRepo;      

        public HomeController(IRepository<Cafe> cafeRepo,IUserRepository<User> userRepo)
        {
            this.cafeRepo = cafeRepo;
            this.userRepo = userRepo;
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
            var user = await userRepo.GetById(userId);
            
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
        public async Task<IActionResult> SearchResult([FromForm]SearchVm searchVm)
        {
            var cafes = await cafeRepo.GetAll();
            var result = cafes.Where(c => c.CafeName.Contains(searchVm.SearchName)).ToList();
            var email = searchVm.User.Email;


            if (result.Any())
            {
                var model = new SearchVm()
                {
                    Cofes = cafes,
                    User = searchVm.User,
                    SearchName = searchVm.SearchName,
                    
                    ResultSearch = result
                };

                return View(model);
            }
            else
            {
                var model = new SearchVm()
                {
                    Cofes = cafes,
                    User = searchVm.User,
                    SearchName = searchVm.SearchName,
                    
                    ResultSearch = "کافه ای با این نام وجود ندارد"
                };

                return View(model);
            }
        }
    }
}
