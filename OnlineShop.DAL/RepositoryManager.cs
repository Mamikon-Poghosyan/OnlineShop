using OnlineShop.Core.Abstractions;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.DAL.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace OnlineShop.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly OnlineShopDBContext _dbContext;
        public RepositoryManager(OnlineShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        private ISignInRepository _signInRepository;
        public ISignInRepository SignInSystems => _signInRepository ?? (_signInRepository = new SignInRepository(_dbContext));
        private IUserRepository _userRepository;
        public IUserRepository Users => _userRepository ?? (_userRepository = new UserRepository(_dbContext));
        private IProductRepository _product;
        public IProductRepository Products => _product ?? (_product = new ProductRepository(_dbContext));
        private ICategoryRepository _category;
        public ICategoryRepository Categoryes => _category ?? (_category = new CategoryRepository(_dbContext));

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new DatabaseTransaction(_dbContext, isolationLevel);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
