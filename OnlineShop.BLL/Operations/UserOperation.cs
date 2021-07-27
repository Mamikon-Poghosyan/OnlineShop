using Microsoft.Extensions.Logging;
using OnlineShop.Core.Abstractions;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Exceptions;

namespace OnlineShop.BLL.Operations
{
    public class UserOperation : IUserOperation
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<UserOperation> _logger;
        public UserOperation(IRepositoryManager repositoryManager, ILogger<UserOperation> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
        public UserModel GetUser(int id)
        {
            _logger.LogInformation("UserOperation GetUserID started");
            var result = _repositoryManager.Users.GetUser(id) ?? throw new LogicException("Wrong User ID");
            _logger.LogInformation("UserOperation GetUserID finished");
            return result;
        }
    }
}
