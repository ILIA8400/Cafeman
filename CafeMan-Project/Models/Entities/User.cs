using Microsoft.AspNetCore.Identity;

namespace CafeMan_Project.Models.Entities
{
    public class User : IdentityUser
    {

        public bool IsCafeOwner { get; set; } = false;
        public ICollection<Cafe> Cafes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Favourite> Favourites { get; set; }

    }
}
