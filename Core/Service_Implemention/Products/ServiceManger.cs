using AutoMapper;
using Domain_Layer.Contract;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Service_Abstrction.Product;
using Service_Implemention.Basket;
using Service_Implemention.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Products
{
    public class ServiceManger(IUnitOfWork _unitOfWork, UserManager<ApplicationUser> _userManager,IMapper _mapper, IBasketReposatiry _basketReposatiry) : IServiceManger
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        private readonly Lazy<IBasketService> _LazyBasketService = new Lazy<IBasketService>(() => new BasketService(_basketReposatiry, _mapper));
        private readonly Lazy<IAuthenticationService> _authenticationService = new Lazy<IAuthenticationService>(() => new AuthentctionService(_userManager));
        public IProductService productService => _LazyproductService.Value;
        public IBasketService BasketService => _LazyBasketService.Value;
        public IAuthenticationService authenticationService => _authenticationService.Value;
    }
}
