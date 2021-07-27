using System.Collections.Generic;

namespace OnlineShop.Core.Entities
{
    public partial class User : EntityBase
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Wallet { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public virtual SignInSystem UserNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
