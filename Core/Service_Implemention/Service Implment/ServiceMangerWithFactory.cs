using Service_Abstrction.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Service_Implment
{
    class ServiceMangerWithFactory (Func<IProductService> ProductFactory,
        Func<IOrderService> OrderFactory ,
        Func<IAuthenticationService> authFactory,
        Func<IBasketService> BasketFactory) : IServiceManger
    {
        public IProductService productService => ProductFactory.Invoke();

        public IBasketService BasketService => BasketFactory.Invoke();

        public IAuthenticationService authenticationService => authFactory.Invoke();

        public IOrderService orderService => OrderFactory.Invoke();
    }
}
