using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CafeMan_Project.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage ="این قسمت نباید خالی باشه")]
        [EmailAddress(ErrorMessage ="ایمیل یا رمز عبور اشتباه است")]
        public string Email { get; set; }

        [Length(8,30,ErrorMessage ="رمز عبور حداقل 8 کاراکتر")]
        [Required(ErrorMessage = "این قسمت نباید خالی باشه")]
        public string Pass { get; set; }
    }
}
