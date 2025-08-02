using APIS_NET8_CSHARP12_IoC.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace APIS_NET8_CSHARP12_IoC.Configurations
{
    public static class MiddlewaresConfiguration
    {
        public static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
