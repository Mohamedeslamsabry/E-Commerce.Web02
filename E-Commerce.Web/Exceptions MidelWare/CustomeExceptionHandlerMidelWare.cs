using Domain_Layer.Exceptions;
using Shared.Error_Models;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.Exceptions_MidelWare
{
    public class CustomeExceptionHandlerMidelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomeExceptionHandlerMidelWare> _logger;

        public CustomeExceptionHandlerMidelWare(RequestDelegate next, ILogger<CustomeExceptionHandlerMidelWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Occurs Error"); // Internal server Error (500,....)=> Back End 

                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = ex switch
                {
                    NotFoundExceptions => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };




                //context.Response.ContentType = "Application/Json";
                var response = new ErrorToReturn()
                {
                    ErrorMessage = ex.Message,
                    StatusCode = context.Response.StatusCode //Number In Body
                };

                //var ResponseToReturn = JsonSerializer.Serialize(response);

                await context.Response.WriteAsJsonAsync(response);

            }
        }
    }
}
