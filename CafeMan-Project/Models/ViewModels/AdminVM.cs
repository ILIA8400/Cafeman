using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Models.ViewModels
{
    public class AdminVM
    {
        public List<Cafe> Cafes { get; set; }
        public List<User> Users { get; set; }
        public ICollection<User> Admins { get; set; }
    }
}
