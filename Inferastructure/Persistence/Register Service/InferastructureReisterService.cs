
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistence.Data.Identity;
using StackExchange.Redis;
namespace Persistence.Register_Service
{
    public static class InferastructureReisterService
    {
        public static IServiceCollection AddInferstructureService(this IServiceCollection Services, IConfiguration Configuration)
        {
            #region AddDbContext
            Services.AddDbContext<StroreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DeafultConnection"));
            });
            #endregion

            #region AddScoped => DataSeeding
            Services.AddScoped<IDataSeeding, DataSeeding>();
            #endregion

            #region UnitOfWork
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region BasketReposiatry
            Services.AddScoped<IBasketReposatiry, BasketReposiatry>();
            #endregion

            #region ConnectionMultiplexer
            Services.AddSingleton<IConnectionMultiplexer>( (_) =>
            {
               return ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RediusConnection")!);
            });
            #endregion

            #region IdentytDContext
            Services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });
            #endregion 

            #region ApplicationUser And IdentityRole
            Services.AddIdentityCore<ApplicationUser>() // Options ممكن ابعت
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<StoreIdentityDbContext>();
            #endregion

            return Services;
        }
    }
}
