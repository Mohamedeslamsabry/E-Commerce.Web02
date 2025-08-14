using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DbContexts;
using Persistence.Data.Identity;

namespace Admin_DashBord
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();

            #region AddDbContext
            builder.Services.AddDbContext<StroreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection"));

            });
            #endregion

            #region IdentytDContext
            builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            #endregion

            #region ApplicationUser And IdentityRole

            #region Can Not
            //builder.Services.AddIdentityCore<ApplicationUser>() // Options ممكن ابعت
            //    .AddRoles<IdentityRole>()
            //    .AddSignInManager()
            //    .AddEntityFrameworkStores<StoreIdentityDbContext>(); 
            #endregion

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<StoreIdentityDbContext>()
              .AddDefaultTokenProviders();
            #endregion

            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Login}/{id?}");
            #endregion

            app.Run();
        }
    }
}
