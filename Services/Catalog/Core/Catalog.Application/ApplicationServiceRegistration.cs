using Microsoft.Extensions.DependencyInjection;
using Catalog.Domain.Entities;
using Catalog.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Catalog.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });
            return services;
        }
    }
}
