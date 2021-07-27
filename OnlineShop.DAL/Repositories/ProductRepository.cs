using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDBContext dBContext)
            : base(dBContext)
        {
        }
        public void AddProduct(ProductModel model)
        {            
            dBContext.Products.Add(new Product 
            {
                //CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                //Pictures = model.Pictures,
                //UnitPrice = model.UnitPrice                
            });
        }
    }
}
