using Domain_Layer.Contract;
using E_Commerce.Web.Exceptions_MidelWare;
using Swashbuckle.AspNetCore.SwaggerUI;

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
            app.UseSwaggerUI(Options =>
            {
                Options.ConfigObject = new ConfigObject()
                {
                    DisplayRequestDuration = true
                };
                Options.DocumentTitle = "Talbat";
                Options.DocExpansion(DocExpansion.None);
                Options.EnablePersistAuthorization();
                Options.EnableFilter();
            });
            return app;
        }
    }
}
