using Shared.DTO.Product;
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
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId, int? TypeId);

        //Get Product By Id 
        Task<ProductDto> GetProductByIdAsync(int id);

        //Get all Prand
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        //Get all Type
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}
