using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class StroreDbContext : DbContext//DbContextOptions<StroreDbContext> options
    {

        public StroreDbContext(DbContextOptions<StroreDbContext> options):base(options) 
        {
            
        }

        #region Dbset
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefrence).Assembly);
        } 
        #endregion
    }
}
