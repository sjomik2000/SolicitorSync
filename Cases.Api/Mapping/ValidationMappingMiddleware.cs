using Cases.Contracts.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Cases.Api.Mapping
{
    // This file is used to initialize ValidationMappingMiddleWare
    // Using Validation checks (from Cases.Application.CaseValidator)
    // if Validation is failed the ValidationFailure response within
    // JSON format is sent back to the server.
    public class ValidationMappingMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMappingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException ex)
            {
                context.Response.StatusCode = 400;
                var validationFailureResponse = new ValidationFailureResponse()
                {
                    Errors = ex.Errors.Select(x => new ValidationResponse
                    {
                        property_name = x.PropertyName,
                        message = x.ErrorMessage
                    })
                };
                await context.Response.WriteAsJsonAsync(validationFailureResponse);
            }
        }
    }
}
