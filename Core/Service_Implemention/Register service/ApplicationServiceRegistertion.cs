using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Service_Abstrction.Product;
using Service_Implemention.Basket;
using Service_Implemention.Identity;
using Service_Implemention.Orders;
using Service_Implemention.Products;
using Service_Implemention.Service_Implment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAuthenticationService = Service_Abstrction.Product.IAuthenticationService;

namespace Service_Implemention.Register_service
{
    public static class ApplicationServiceRegistertion
    {

        public static IServiceCollection AddApplictionService(this IServiceCollection Services)
        {
            Services.AddAutoMapper(typeof(AssemblyRef).Assembly);
            Services.AddScoped<IServiceManger, ServiceMangerWithFactory>();
            //Services.AddScoped<IBasketService, BasketService>(); // Becouse ServiceManger

            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<Func<IProductService>>(Provider =>
            () => Provider.GetRequiredService<IProductService>()
            );

            Services.AddScoped<IBasketService, BasketService>();
            Services.AddScoped<Func<IBasketService>>(Provider =>
            () => Provider.GetRequiredService<IBasketService>()
            );


            Services.AddScoped<IOrderService, OrderService>();
            Services.AddScoped<Func<IOrderService>>(Provider =>
            () => Provider.GetRequiredService<IOrderService>()
            );


            Services.AddScoped<IAuthenticationService, AuthentctionService>();
            Services.AddScoped<Func<IAuthenticationService>>(Provider =>
            () => Provider.GetRequiredService<IAuthenticationService>()
            );






            return Services;
        }
     
    }
}
