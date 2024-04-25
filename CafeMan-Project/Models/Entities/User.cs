namespace CafeMan_Project.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public decimal? Phone { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public bool IsCafeOwner { get; set; }
        public ICollection<Cafe> Cafes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
