using Domain_Layer.Contract;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DbContexts;
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

        public async Task DataSeedAsync()
        {
            var PendingMigration = await _stroreDbContext.Database.GetPendingMigrationsAsync();
            if (PendingMigration.Any())
            {
                _stroreDbContext.Database.Migrate();
            }

            if (!_stroreDbContext.productBrands.Any())
            {
                //D:\Desktop\Back end (.Net) videos\Eng  Aliaa tarek\Web Api\Project WebApi\E-Commerce.Web\Inferastructure\Persistence\Data\DataSeed\brands.json
                //var ProductPrandData = File.ReadAllTextAsync(@"..\Inferastructure\Persistence\Data\DataSeed\brands.json");
                var ProductPrandData = File.OpenRead(@"..\Inferastructure\Persistence\Data\DataSeed\brands.json");

                var ProductPrand = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductPrandData);

                if (ProductPrand != null && ProductPrand.Any())
                {
                    await _stroreDbContext.AddRangeAsync(ProductPrand);
                }
            }

            if (!_stroreDbContext.productTypes.Any())
            {
                var ProductTypeData = File.OpenRead(@"..\Inferastructure\Persistence\Data\DataSeed\types.json");
                var ProductType = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                if (ProductType != null && ProductType.Any())
                {
                    await _stroreDbContext.AddRangeAsync(ProductType);
                }
            }

            if (!_stroreDbContext.products.Any())
            {
                var ProductData = File.OpenRead(@"..\Inferastructure\Persistence\Data\DataSeed\Products.json");
                var Product = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                if (Product != null && Product.Any())
                {
                    await _stroreDbContext.AddRangeAsync(Product);
                }
            }

            await _stroreDbContext.SaveChangesAsync();
        }
    }
}
