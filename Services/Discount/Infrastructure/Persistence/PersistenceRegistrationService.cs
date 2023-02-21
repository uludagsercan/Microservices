using Application.Repositories.Discount;
using Application.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Contexts;
using Persistence.Repositories.DiscountRepository;

namespace Persistence
{
    public static class PersistenceRegistrationService
    {
        public static IServiceCollection AddDiscountPersistenceService(this IServiceCollection services)
        {
            services.AddSingleton<DiscountRepositoryContext>(sp =>
            {
                var psqlSetting = sp.GetRequiredService<IOptions<PostgreSQLSetting>>().Value;
                var postgreSqlRepositoryContext = new DiscountRepositoryContext(psqlSetting.ConnectionString);
                return postgreSqlRepositoryContext;
            });

            services.AddScoped<IDiscountWriteRepository, DiscountWriteRepository>();
            services.AddScoped<IDiscountReadRepository, DiscountReadRepository>();
            return services;
        }
    }
}
