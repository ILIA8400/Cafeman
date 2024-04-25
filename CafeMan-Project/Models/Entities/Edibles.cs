namespace CafeMan_Project.Models.Entities
{
    public class Edibles
    {
        public int EdiblesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool? IsFood { get; set; }
        public bool? IsDrink { get; set; }
        public bool? IsDessert { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
