using Microsoft.AspNetCore.Identity;

namespace CafeMan_Project.Infra
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "رمز عبور شما باید شامل حروف کوچک باشد" };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "رمز عبور شما باید شامل حروف بزرگ باشد." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = nameof(DuplicateEmail), Description = "این ایمیل قبلا استفاده شده" };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(DuplicateUserName), Description = "این ایمیل قبلا استفاده شده" };
        }
    }
}
