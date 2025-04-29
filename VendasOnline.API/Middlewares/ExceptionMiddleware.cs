using System.Net;
using System.Text.Json;

namespace VendasOnline.API.Middlewares
{
    public class ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        private readonly JsonSerializerOptions serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exceção não tratada ocorreu");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde.",
                detailedMessage = exception.Message
            };

            var json = JsonSerializer.Serialize(response, serializerOptions);

            await context.Response.WriteAsync(json);
        }
    }
}
