using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICafeRepository<Cafe> cafe;
        private readonly IRepository<Comment> comment;
        private readonly IRepository<Edibles> edible;

        public ProfileController(ICafeRepository<Cafe> cafe,IRepository<Comment> comment,IRepository<Edibles> edible)
        {
            this.cafe = cafe;
            this.comment = comment;
            this.edible = edible;
        }


        [Route("Profile")]
        public async Task<IActionResult> Profile(int q)
        {

            var cafes = await cafe.GetById(q);
            var comments = await comment.GetAll();
            var edibles = await edible.GetAll();

            var profileViewModel = new ProfileViewModel
            {
                Cafe = cafes,
                Comments = comments.Where(c => c.CafeId == q).ToList(),
                Edibles = edibles.Where(c=>c.CafeId == q).ToList()  //Problom =========> menu
            };

            
            if(profileViewModel.Cafe == null)
                return BadRequest();

            return View(profileViewModel);
        }
    }
}
