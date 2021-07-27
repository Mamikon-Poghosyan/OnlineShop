using System.Collections.Generic;

namespace OnlineShop.Core.Entities
{
    public partial class Category : EntityBase
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
