using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Models.ViewModels
{
    public class HomeAccountVM
    {
        public List<Cafe>? Cofes { get; set; }
        public User User { get; set; }

        public List<Cafe>? UserCafes { get; set; }
        public string? SearchName { get; set; }
        public object? ResultSearch { get; set; }
    }
}
