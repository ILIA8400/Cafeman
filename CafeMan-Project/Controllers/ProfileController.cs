using CafeMan_Project.Models.Entities;
using CafeMan_Project.Models.ViewModels;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRepository<Cafe> cafe;
        private readonly IRepository<Comment> comment;
        private readonly IRepository<Edibles> edible;

        public ProfileController(IRepository<Cafe> cafe,IRepository<Comment> comment,IRepository<Edibles> edible)
        {
            this.cafe = cafe;
            this.comment = comment;
            this.edible = edible;
        }


        [Route("Profile/{CafeId:int}")]
        public IActionResult Profile(int CafeId)
        {
            var cafes = cafe.GetById(CafeId);
            var comments = comment.GetAll();
            var edibles = edible.GetAll();

            var profileViewModel = new ProfileViewModel
            {
                Cafe = cafes,
                Comments = comments.Where(c => c.CafeId == CafeId).ToList(),
                Edibles = edibles.Where(c=>c.CafeId == CafeId).ToList()  //Problom =========> menu
            };
            
            if(profileViewModel.Cafe == null)
                return NotFound();

            return View(profileViewModel);
        }
    }
}
