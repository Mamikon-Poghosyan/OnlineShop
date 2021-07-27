using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDBContext dBContext)
            : base(dBContext)
        {
        }
    }
}
