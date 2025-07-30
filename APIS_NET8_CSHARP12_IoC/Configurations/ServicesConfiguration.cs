using APIS_NET8_CSHARP12_Shared.Models.InjecaoDependencia;
using Microsoft.Extensions.DependencyInjection;

namespace APIS_NET8_CSHARP12_IoC.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // ConfigureDefaultDI(builder.Services);

            ConfigureKeyedDI(services);
        }

        static void ConfigureDefaultDI(IServiceCollection services)
        {
            services.AddSingleton<IInjecaoDependencia, InjecaoDependencia>();
            services.AddScoped<IInjecaoDependencia, InjecaoDependencia>();
            services.AddTransient<IInjecaoDependencia, InjecaoDependencia>();
        }

        static void ConfigureKeyedDI(IServiceCollection services)
        {
            services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonUm");
            services.AddKeyedSingleton<IInjecaoDependencia, InjecaoDependencia>("SingletonDois");

            services.AddKeyedScoped<IInjecaoDependencia, InjecaoDependencia>("ScopedUm");
            services.AddKeyedScoped<IInjecaoDependencia, InjecaoDependencia>("ScopedDois");

            services.AddKeyedTransient<IInjecaoDependencia, InjecaoDependencia>("TransientUm");
            services.AddKeyedTransient<IInjecaoDependencia, InjecaoDependencia>("TransientDois");
        }
    }
}
