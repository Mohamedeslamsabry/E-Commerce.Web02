using Domain_Layer.Contract;
using E_Commerce.Web.Exceptions_MidelWare;

namespace E_Commerce.Web.Extension
{
    public static class WebApplictionRegistertion
    {
        public static async Task DataSeedingAsync(this WebApplication app)
        {
            using var Scope = app.Services.CreateScope();
            var ObjOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjOfDataSeeding.DataSeedAsync();
            await ObjOfDataSeeding.IdentityDataSeedingAsync();
        }

        public static IApplicationBuilder UseCustomeExceptionMidelWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomeExceptionHandlerMidelWare>();
            return app;
        }

        public static IApplicationBuilder UseSwiggerMidelWare(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
