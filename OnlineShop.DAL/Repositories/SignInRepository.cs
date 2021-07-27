using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Entities;

namespace OnlineShop.DAL.Repositories
{
    public class SignInRepository : RepositoryBase<SignInSystem>, ISignInRepository
    {
        public SignInRepository(OnlineShopDBContext dBContext)
            : base(dBContext)
        {
        }
    }
}
