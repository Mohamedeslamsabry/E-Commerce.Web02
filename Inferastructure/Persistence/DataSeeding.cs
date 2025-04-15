using Domain_Layer.Contract;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StroreDbContext _stroreDbContext) : IDataSeeding
    {

        public void DataSeed()
        {
            if (_stroreDbContext.Database.GetPendingMigrations().Any())
            {
                _stroreDbContext.Database.Migrate();
            }

            if (!_stroreDbContext.productBrands.Any())
            {
                //D:\Desktop\Back end (.Net) videos\Eng  Aliaa tarek\Web Api\Project WebApi\E-Commerce.Web\Inferastructure\Persistence\Data\DataSeed\brands.json
                var ProductPrandData = File.ReadAllText(@"..\Inferastructure\Persistence\Data\DataSeed\brands.json");
                var ProductPrand = JsonSerializer.Deserialize<List<ProductBrand>>(ProductPrandData);
                if(ProductPrand != null && ProductPrand.Any())
                {
                    _stroreDbContext.AddRange(ProductPrand);
                }
            }

            if (!_stroreDbContext.productTypes.Any())
            {
                var ProductTypeData = File.ReadAllText(@"..\Inferastructure\Persistence\Data\DataSeed\types.json");
                var ProductType = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);
                if (ProductType != null && ProductType.Any())
                {
                    _stroreDbContext.AddRange(ProductType);
                }
            }

            if (!_stroreDbContext.products.Any())
            {
                var ProductData = File.ReadAllText(@"..\Inferastructure\Persistence\Data\DataSeed\Products.json");
                var Product = JsonSerializer.Deserialize<List<Product>>(ProductData);
                if (Product != null && Product.Any())
                {
                    _stroreDbContext.AddRange(Product);
                }
            }

            _stroreDbContext.SaveChanges();
        }
    }
}
