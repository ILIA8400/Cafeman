using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Models.ViewModels
{
    public class HomeAccountVM
    {
        public List<Cafe>? Cofes { get; set; }
        public User User { get; set; }
        public SearchVm? searchVm { get; set; }

    }
}
