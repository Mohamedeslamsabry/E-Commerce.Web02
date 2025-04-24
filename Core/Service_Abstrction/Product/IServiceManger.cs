using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Abstrction.Product
{
    public interface IServiceManger
    {
        public IProductService productService { get; }
        public IBasketService BasketService { get; }
    }
}
