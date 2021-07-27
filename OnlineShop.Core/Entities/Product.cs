using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.Entities
{
    public partial class Product : EntityBase
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public byte[] Pictures { get; set; }
        public decimal? UnitPrice { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
