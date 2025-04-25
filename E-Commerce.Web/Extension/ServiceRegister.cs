using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Extension
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddSwigerService(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }


        public static IServiceCollection AddWebAppictionService(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.ValidtionErrorResponse;
            });
            return Services;
        }

    }
}   
