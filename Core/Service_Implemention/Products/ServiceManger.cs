using AutoMapper;
using Domain_Layer.Contract;
using Service_Abstrction.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Products
{
    public class ServiceManger(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManger
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService productService => _LazyproductService.Value;
    }
}
