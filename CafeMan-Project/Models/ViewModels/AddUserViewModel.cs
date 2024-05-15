using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CafeMan_Project.Models.ViewModels
{
    public class AddUserViewModel
    {
        [StringLength(40,MinimumLength =11,ErrorMessage ="حداقل 11 و حداکثر 40 کاراکتر")]
        [Required(ErrorMessage ="این فیلد نباید خالی باشه")]
        [EmailAddress(ErrorMessage ="این قسمت باید ایمیل باشه")]
        public string Email { get; set; }


        [Required(ErrorMessage = "این فیلد نباید خالی باشه")]
        [StringLength(40,MinimumLength =8, ErrorMessage = "حداقل 8 و حداکثر 40 کاراکتر")]
        public string Password { get; set; }


        [Required(ErrorMessage = "این فیلد نباید خالی باشه")]
        [Compare("Password",ErrorMessage ="تکرار رمز عبور اشتباه است")]
        public string RepeatPassword { get; set; }

    }
}
