using Domain_Layer.Contract;
using E_Commerce.Web.Exceptions_MidelWare;
using E_Commerce.Web.Extension;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Persistence.Register_Service;
using Service_Implemention.Register_service;

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

            #region Add Swigwe Service
            builder.Services.AddSwigerService();
            #endregion

            #endregion

            #region Added By Me

            #region Presitance (Register Service) 
            builder.Services.AddInferstructureService(builder.Configuration);

            #endregion

            #region Service Implement (Register)
            builder.Services.AddApplictionService();
            #endregion

            #endregion

            #region Model State (Validtion)
            builder.Services.AddWebAppictionService();
            #endregion

            #endregion

            var app = builder.Build();

            #region DataSeeding
            await app.DataSeedingAsync();
            #endregion

            #region  Configure the HTTP request pipeline.

            #region Custome Midel ware
            app.UseCustomeExceptionMidelWare();
            #endregion

            #region Old Way Custome Midel ware
            //Custome Midel ware
            //app.Use(async (HttpContext, RequestDelegate) =>
            //{
            //    Console.WriteLine("Hello Start");
            //    await RequestDelegate.Invoke(); // next MidelWare
            //    Console.WriteLine("Hello End");
            //    Console.WriteLine(HttpContext.Response.Body);
            //}); 
            #endregion

            #region Added Authomticly
            if (app.Environment.IsDevelopment())
            {
                app.UseSwiggerMidelWare();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            #endregion

            app.Run();
        }
    }
}
