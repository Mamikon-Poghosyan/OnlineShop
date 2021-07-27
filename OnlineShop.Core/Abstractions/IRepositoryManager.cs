using OnlineShop.Core.Abstractions.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace OnlineShop.Core.Abstractions
{
    public interface IRepositoryManager
    {
        ISignInRepository SignInSystems { get; }
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categoryes { get; }
        IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
