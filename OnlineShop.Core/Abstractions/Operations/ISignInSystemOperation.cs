using Microsoft.AspNetCore.Http;
using OnlineShop.Core.BusinessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Core.Abstractions.Operations
{
    public interface ISignInSystemOperation
    {
        IEnumerable<SignInSystemViewModel> GetAll();
        SignInSystemViewModel Get(int id);
        Task Logout(HttpContext context);
        Task Register(RegisterModel model, HttpContext context);
        Task Login(LoginModel model, HttpContext context);
    }
}
