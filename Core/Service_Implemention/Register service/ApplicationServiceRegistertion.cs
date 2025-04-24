using Microsoft.Extensions.DependencyInjection;
using Service_Abstrction.Product;
using Service_Implemention.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Register_service
{
    public static class ApplicationServiceRegistertion
    {

        public static IServiceCollection AddApplictionService(this IServiceCollection Services)
        {
            Services.AddAutoMapper(typeof(AssemblyRef).Assembly);
            Services.AddScoped<IServiceManger, ServiceManger>();
            return Services;
        }
     
    }
}
