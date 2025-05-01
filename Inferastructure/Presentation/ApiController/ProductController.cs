using Microsoft.AspNetCore.Mvc;
using Service_Abstrction.Product;
using Shared;
using Shared.DTO.Product;

namespace Presentation.ApiController
{
    public class ProductController(IServiceManger _serviceManger) : ApiBaseController
    {
        #region Get All Product

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProduct([FromQuery] ProductQueryParamter productQuery)//int ? BrandId , int ? TypeId , ProductSortingSpecifications productSorting
        {
            var Products = await _serviceManger.productService.GetAllProductsAsync(productQuery);
            return Ok(Products);
        }
        #endregion

        #region Get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var Product = await _serviceManger.productService.GetProductByIdAsync(id);
            return Ok(Product);
        }
        #endregion

        #region Get All Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _serviceManger.productService.GetAllBrandsAsync();
            return Ok(brands);
        }
        #endregion

        #region Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var brands = await _serviceManger.productService.GetAllTypesAsync();
            return Ok(brands);
        } 
        #endregion
    }
}
