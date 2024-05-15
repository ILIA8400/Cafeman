namespace CafeMan_Project.Models.Entities
{
    public class CafeImage
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public string Path { get; set; }
        public Cafe Cafe { get; set; }
        public int CafeId { get; set; }
    }
}
