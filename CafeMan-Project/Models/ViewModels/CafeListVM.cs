using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Models.ViewModels
{
    public class CafeListVM
    {
        public List<Cafe> Cafes { get; set; }
        public string OwnerEmail { get; set; }
    }
}
