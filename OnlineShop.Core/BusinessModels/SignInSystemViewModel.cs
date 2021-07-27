using OnlineShop.Core.Enum;

namespace OnlineShop.Core.BusinessModels
{
    public class SignInSystemViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
