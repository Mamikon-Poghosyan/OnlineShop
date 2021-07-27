using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Entities;
using System.Linq;

namespace OnlineShop.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(OnlineShopDBContext dBContext)
            : base(dBContext)
        {
        }
        public UserModel GetUser(int id)
        {
            var result = from signin in dBContext.SignInSystems
                         join user in dBContext.Users on signin.SignInId equals user.UserId
                         where signin.SignInId == id
                         select new UserModel
                         {
                             SignInId = signin.SignInId,
                             Email = signin.Email,
                             Password = signin.Password,
                             UserId = user.UserId,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Wallet = user.Wallet
                         };
            return result.FirstOrDefault();
        }
    }
}