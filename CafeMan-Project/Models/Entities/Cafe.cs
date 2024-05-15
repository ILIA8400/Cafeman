namespace CafeMan_Project.Models.Entities
{
    public class Cafe
    {
        public int CafeId { get; set; }
        public string CafeName { get; set; }
        public string CafeDescription { get; set; }
        public double? Star { get; set; }
        public int? Tel { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
        public string Location { get; set; }
        public string? Details { get; set; }
        public string? PriceRange { get; set; }
        public User Users { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Edibles> Edibles { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? Rank { get; set; }
        public ICollection<CafeImage> CafeImages { get; set; }
    }
}
