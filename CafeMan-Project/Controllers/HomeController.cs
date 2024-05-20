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
        private readonly ILogger<HomeController> logger;

        public HomeController(ICafeRepository<Cafe> cafeRepo,UserManager<User> userManager,ILogger<HomeController> logger)
        {
            this.cafeRepo = cafeRepo;
            this.userManager = userManager;
            this.logger = logger;
        }



        public async Task<IActionResult> Index()
        {
            logger.Log(LogLevel.Information,eventId:200, "*************** Application is started ***************");
            ViewBag.Title = "Cafeman";

            var cafes = await cafeRepo.GetAll();
            return View(cafes);
        }



        [Authorize(Policy = "Roles")]
        public async Task<IActionResult> HomeAccount()
        {
            ViewBag.Title = "Cafeman";
            var userId = HttpContext.Request.Cookies["usi"];

            var cafes = await cafeRepo.GetAll();
            var user = await userManager.FindByIdAsync(userId);
            
            var model = new HomeAccountVM()
            {
                Cofes = cafes,
                User = user
            };

            TempData["userId"] = userId;
            HttpContext.Response.Cookies.Delete("usi");

            if(user == null)
                return BadRequest(ModelState);
            else
                return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SearchResult([Bind("SearchName")] HomeAccountVM model)
        {
            ViewBag.Title = "صحفه اصلی";

            var cafes = await cafeRepo.GetOwnerCafe();

            List<Cafe>? result;
            if(model.SearchName != null)
            {
                result = cafes.Where(c => c.CafeName.Contains(model.SearchName)).ToList();
                if (!result.Any())
                    result = null;            
            }
            else
            {
               result = null;
            }
                

            
            var userId = TempData.Peek("userId").ToString();
            
            var user = await userManager.FindByIdAsync(userId);

            if (result != null)
            {
                var vm = new HomeAccountVM()
                {
                    Cofes = cafes,
                    User = user,
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
                    User = user,
                    SearchName = model.SearchName,
                    
                    ResultSearch = "کافه ای با این نام وجود ندارد"
                };

                return View(vm);
            }
        }
    }
}
