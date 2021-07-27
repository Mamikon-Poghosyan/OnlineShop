using OnlineShop.Core.Enum;

namespace OnlineShop.Core.Entities
{
    public partial class SignInSystem : EntityBase
    {
        public int SignInId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
