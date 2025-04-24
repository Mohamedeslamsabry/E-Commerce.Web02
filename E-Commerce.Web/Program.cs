
using Domain_Layer.Contract;
using E_Commerce.Web.Exceptions_MidelWare;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data.DbContexts;
using Persistence.Implment_Repo;
using Service_Abstrction.Product;
using Service_Implemention;
using Service_Implemention.Products;
using Service_Implemention.Profiles;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region  Add services to the container.

            #region Added Authomicly

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            #region Added By Me

            #region AddDbContext
            builder.Services.AddDbContext<StroreDbContext>(options =>
                  {
                      options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection"));
                  });
            #endregion

            #region AddScoped => DataSeeding
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region autoMaper

            builder.Services.AddAutoMapper(typeof(AssemblyRef).Assembly);

            #endregion

            #region ServiceManger
            builder.Services.AddScoped<IServiceManger, ServiceManger>();
            #endregion

            #endregion

            #endregion

            var app = builder.Build();

            #region DataSeeding
            using var Scope = app.Services.CreateScope();
            var ObjOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjOfDataSeeding.DataSeedAsync();
            #endregion

            #region  Configure the HTTP request pipeline.

            app.UseMiddleware<CustomeExceptionHandlerMidelWare>();

            //Custome Midel ware
            //app.Use(async (HttpContext, RequestDelegate) =>
            //{
            //    Console.WriteLine("Hello Start");
            //    await RequestDelegate.Invoke(); // next MidelWare
            //    Console.WriteLine("Hello End");
            //    Console.WriteLine(HttpContext.Response.Body);
            //});





            #region Added Authomticly
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            #region Added By Me

            #endregion

            #endregion

            app.Run();
        }
    }
}
