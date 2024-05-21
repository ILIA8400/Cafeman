using CafeMan_Project.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeMan_Project.Models.ViewModels
{
    public class HomeAccountVM
    {
        public List<Cafe>? Cofes { get; set; }
        public User User { get; set; }

        public List<Cafe>? UserCafes { get; set; }

        //[Remote("SearchResult", "Home")]
        public string? SearchName { get; set; }
        public object? ResultSearch { get; set; }
    }
}
