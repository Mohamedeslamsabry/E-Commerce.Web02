using Shared;
using Shared.DTO.Product;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Abstrction.Product
{
    public interface IProductService
    {
        //Get all Product
        Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParamter productQuery);

        //Get Product By Id 
        Task<ProductDto> GetProductByIdAsync(int id);

        //Get all Prand
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        //Get all Type
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}
