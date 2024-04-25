namespace CafeMan_Project.Models.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public ICollection<Edibles> Edibles { get; set; }
        public int EdiblesId { get; set; }
        public Cafe Cafe { get; set; }
        public int CafeId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
