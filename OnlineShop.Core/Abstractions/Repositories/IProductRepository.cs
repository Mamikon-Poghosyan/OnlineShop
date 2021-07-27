using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void AddProduct(ProductModel model);
    }
}
