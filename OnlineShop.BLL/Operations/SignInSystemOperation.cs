using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnlineShop.Core.Abstractions;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.Core.BusinessModels;
using OnlineShop.Core.Entities;
using OnlineShop.Core.Enum;
using OnlineShop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Operations
{
    public class SignInSystemOperation : ISignInSystemOperation
    {
        private readonly IRepositoryManager _repositories;
        private readonly ILogger<SignInSystemOperation> _logger;
        public SignInSystemOperation(IRepositoryManager onlineShopDBContext, ILogger<SignInSystemOperation> logger)
        {
            _repositories = onlineShopDBContext;
            _logger = logger;
        }
        public SignInSystemViewModel Get(int id)
        {
            _logger.LogInformation("SignInSystemOperations GetSignInSystemID method started");
            var signIn = _repositories.SignInSystems.Get(id) ?? throw new LogicException("Wrong User Id");
            _logger.LogInformation("SignInSystemOperations GetSignInSystemID method finished");
            return new SignInSystemViewModel
            {
                Email = signIn.Email,
                Password = signIn.Password,
                Role = signIn.Role
            };
        }
        public IEnumerable<SignInSystemViewModel> GetAll()
        {
            var data = _repositories.SignInSystems.GetAll();
            var result = data.Select(x => new SignInSystemViewModel
            {
                Email = x.Email,
                Password = x.Password,
                Role = x.Role
            });
            return result;
        }        
        [Obsolete] public void PorcTranzacshni()
        {
            using (var transaction = _repositories.BeginTransaction())
            {
                try
                {   //add   //remove   //delete                    
                    _repositories.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public async Task Login(LoginModel model, HttpContext context)
        {
            SignInSystem user = _repositories.SignInSystems.GetSingle(u => u.Email == model.Email && u.Password == model.Password)
                ?? throw new LogicException("Wrong username or password");
            await Authenticate(user, context);      
        }
        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public async Task Register(RegisterModel model, HttpContext context)
        {
            SignInSystem user = _repositories.SignInSystems.GetSingle(u => u.Email == model.Email);
            
            using (var transaction = _repositories.BeginTransaction())
            {
                try
                {
                    if (user == null)
                    {
                        user = new SignInSystem
                        {
                            Email = model.Email,
                            Password = model.Password,
                            Role = Role.User
                        };
                        _repositories.SignInSystems.Add(user);
                        await _repositories.SaveChangesAsync();
                        await Authenticate(user, context);
                    }
                    else
                    {
                        throw new LogicException("User already exists");
                    }
                    _repositories.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        private async Task Authenticate(SignInSystem user, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(     claims, 
                                                        "ApplicationCookie", 
                                                        ClaimsIdentity.DefaultNameClaimType, 
                                                        ClaimsIdentity.DefaultRoleClaimType
                                                   );
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
