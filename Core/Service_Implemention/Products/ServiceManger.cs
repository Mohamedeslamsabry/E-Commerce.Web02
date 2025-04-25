using AutoMapper;
using Domain_Layer.Contract;
using Service_Abstrction.Product;
using Service_Implemention.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Products
{
    public class ServiceManger(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketReposatiry _basketReposatiry) : IServiceManger
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        private readonly Lazy<IBasketService> _LazyBasketService = new Lazy<IBasketService>(() => new BasketService(_basketReposatiry, _mapper));
        public IProductService productService => _LazyproductService.Value;
        public IBasketService BasketService => _LazyBasketService.Value;
    }
}
