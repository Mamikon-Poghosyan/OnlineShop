using System;
using System.Collections.Generic;

namespace OnlineShop.Core.Entities
{
    public partial class Order : EntityBase
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? DaliveryDate { get; set; }
        public DateTime? DateOfReceipt { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
