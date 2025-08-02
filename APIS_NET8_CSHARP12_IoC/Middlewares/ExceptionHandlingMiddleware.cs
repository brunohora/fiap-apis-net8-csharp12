using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace APIS_NET8_CSHARP12_IoC.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                if (ex != null)
                {
                    _logger.LogError(ex, ex.StackTrace);
                }

                var errorResponse = new
                {
                    OriginalExceptionMessage = ex?.Message,
                    NewMessage = "Ops! Ocorreu um erro interno, mas os detalhes do erro foram capturados. Vamos trabalhar para resolvê-lo o mais rápido possível."
                };

                var json = JsonSerializer.Serialize(errorResponse);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
