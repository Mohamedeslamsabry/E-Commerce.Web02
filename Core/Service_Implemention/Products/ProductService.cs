using AutoMapper;
using Domain_Layer.Contract;
using Domain_Layer.Models;
using Service_Abstrction.Product;
using Shared.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Products
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        #region GetAllProductsAsync
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var Products = await _unitOfWork.genricRepository<Product, int>().GetAllAsync();
            var ProductsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            return ProductsDto;
        }
        #endregion

        #region GetAllBrandsAsync
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var ProductsBrand = await _unitOfWork.genricRepository<ProductBrand, int>().GetAllAsync();
            var ProductsBrandDto = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(ProductsBrand);
            return ProductsBrandDto;
        }
        #endregion

        #region GetAllTypesAsync
        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var ProductsType = await _unitOfWork.genricRepository<ProductType, int>().GetAllAsync();
            var ProductsTypeDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(ProductsType);
            return ProductsTypeDto;
        }
        #endregion

        #region GetProductByIdAsync
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Product = await _unitOfWork.genricRepository<Product, int>().GetByIdAsync(id);
            return _mapper.Map<Product, ProductDto>(Product);
        } 
        #endregion
    }
}
