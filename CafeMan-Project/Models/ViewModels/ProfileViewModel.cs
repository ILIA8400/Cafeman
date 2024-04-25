using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Models.ViewModels
{
    public class ProfileViewModel
    {
        public Cafe Cafe { get; set; }
        public List<Comment> Comments { get; set; }
        public List <Edibles> Edibles { get; set; }
    }

}
