using System.ComponentModel.DataAnnotations.Schema;

namespace CafeMan_Project.Models.Entities
{
    public class Favourite
    {
        public int FavouriteId { get; set; }
        public User User { get; set; }
        public Cafe Cafe { get; set; }
        public int CafeId { get; set; }
    }
}
