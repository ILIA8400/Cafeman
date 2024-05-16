using System.ComponentModel.DataAnnotations;

namespace CafeMan_Project.Models.ViewModels
{
    public class EditUserVM
    {
        public string? Id { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(11)]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(40)]
        public string CurrentPassword { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(40)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
