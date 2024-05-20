using System.ComponentModel.DataAnnotations;

namespace CafeMan_Project.Models.ViewModels
{
    public class CafemanVM
    {
        public string? ID { get; set; }
        [Required]
        public string CafeName { get; set; }

        [Required]
        public string CafeDescription { get; set; }

        [MinLength(8)]
        [MaxLength(8)]
        public int? Tel { get; set; }

        public string? Address { get; set; }
        public string? Website { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
        public string Location { get; set; }
        public string? Details { get; set; }
        public string? PriceRange { get; set; }
    }
}
