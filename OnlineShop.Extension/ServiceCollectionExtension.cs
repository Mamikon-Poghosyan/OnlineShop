using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.BLL.Operations;
using OnlineShop.Core.Abstractions;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.DAL;

namespace OnlineShop.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddConnectDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<OnlineShopDBContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("OnlineShop"));
            });
        }
        public static void AddRepositoryInjection(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void SignInSystemOperation(this IServiceCollection services)
        {
            services.AddScoped<ISignInSystemOperation, SignInSystemOperation>();
        }
        public static void UserOperation(this IServiceCollection services)
        {
            services.AddScoped<IUserOperation, UserOperation>();
        }
        public static void ProductOperation(this IServiceCollection services)
        {
            services.AddScoped<IProductOperation, ProductOperation>();
        }
        public static void AddOperationsInjection(this IServiceCollection services)
        {
            SignInSystemOperation(services);
            UserOperation(services);
            ProductOperation(services);
        }
    }
}
