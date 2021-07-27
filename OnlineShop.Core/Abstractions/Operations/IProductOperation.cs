using OnlineShop.Core.BusinessModels;

namespace OnlineShop.Core.Abstractions.Operations
{
    public interface IProductOperation
    {
        void AddProduct(ProductModel model);
    }
}
