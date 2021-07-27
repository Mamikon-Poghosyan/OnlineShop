using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        UserModel GetUser(int id);
    }
}
