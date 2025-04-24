using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.Error_Models;

namespace E_Commerce.Web.Factories
{
    public static class ApiResponseFactory
    {
        public static IActionResult ValidtionErrorResponse(ActionContext Context)
        {

            var errors = Context.ModelState.Where(M => M.Value!.Errors.Any())
            .Select(M => new ValidtionErrorDetails()
            {
                Field = M.Key,
                Errors = M.Value!.Errors.Select(E => E.ErrorMessage)
            });

            var response = new ValiadtionErrorToReturn()
            {
                validtionErrors = errors
            };
            return new BadRequestObjectResult(response);
        }
    }
}

