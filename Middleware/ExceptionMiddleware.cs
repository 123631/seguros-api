using System.Net;
using System.Text.Json;

namespace SegurosApi.Middleware
{
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception ex) {
                _logger.LogError(ex, "Ocurrió un error no controlado.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
            context.Response.ContentType = "application/json";
            
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Error interno en el servidor.";

            if (exception.Message.Contains("no existe") || exception.Message.Contains("inválidas")) {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
            } else if (exception.Message.Contains("no encontrada")) {
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message;
            }

            context.Response.StatusCode = statusCode;

            var response = new {
                status = statusCode,
                message = message,
                detail = exception.InnerException?.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}