
using Microsoft.Extensions.Configuration;
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

            return Services;
        }
    }
}
