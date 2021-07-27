namespace OnlineShop.Core.Entities
{
    public partial class OrderDetail : EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
