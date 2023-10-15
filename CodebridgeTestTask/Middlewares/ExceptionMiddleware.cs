using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = "";
                if (ex is ValidationException validation)
                    message = validation.Errors.Aggregate("", (acc, err) =>
                    {
                        return acc + err.ErrorMessage + " ";
                    });
                else
                    message = ex.Message;

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Message = message,
                    StackTrace = ex.StackTrace,
                    Name = "ApiException"
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }
}
