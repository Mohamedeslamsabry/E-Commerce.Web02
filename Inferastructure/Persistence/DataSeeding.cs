using Domain_Layer.Contract;
using Domain_Layer.Models.Identity;
using Domain_Layer.Models.OrderModule;
using Domain_Layer.Models.Prpducts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DbContexts;
using Persistence.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StroreDbContext _stroreDbContext ,
        UserManager<ApplicationUser> _userManager , 
        RoleManager<IdentityRole> _roleManager , 
        StoreIdentityDbContext _storeIdentityDb) : IDataSeeding
    {

        public async Task DataSeedAsync()
        {
            try
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

                if (!_stroreDbContext.Set<DeliveryMethod>().Any())
                {
                    var DelivaryData = File.OpenRead(@"..\Inferastructure\Persistence\Data\DataSeed\delivery.json");
                    var Delivary = await JsonSerializer.DeserializeAsync<List<DeliveryMethod>>(DelivaryData);
                    if (Delivary != null && Delivary.Any())
                    {
                        await _stroreDbContext.AddRangeAsync(Delivary);
                    }
                }


                await _stroreDbContext.SaveChangesAsync();
            }
            catch (Exception exc)
            {

                // TODO 
            }
        }

        public async Task IdentityDataSeedingAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }

                if (!_userManager.Users.Any())
                {
                    var User01 = new ApplicationUser()
                    {
                        Email = "Mohamed@gmail.com",
                        DisplayName = "Mohamed Eslam",
                        PhoneNumber = "0123456789",
                        UserName = "MohamedEslam"
                    };

                    var User02 = new ApplicationUser()
                    {
                        Email = "Rawan@gmail.com",
                        DisplayName = "Rawan Tarek",
                        PhoneNumber = "0123456799",
                        UserName = "RawanTarek"
                    };

                    await _userManager.CreateAsync(User01, "P@ssw0rd");
                    await _userManager.CreateAsync(User02, "P@ssw0rd");

                    await _userManager.AddToRoleAsync(User01, "Admin");
                    await _userManager.AddToRoleAsync(User02, "SuperAdmin");
                }

                await _storeIdentityDb.SaveChangesAsync();

            }
            catch (Exception exc)
            {
                //TODO
            }
            ;
        }
    }
}
