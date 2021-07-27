using OnlineShop.Core.BusinessModels;

namespace OnlineShop.Core.Abstractions.Operations
{
    public interface IUserOperation
    {
        UserModel GetUser(int id);
    }
}
