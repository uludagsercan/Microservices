using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using FreeCourse.Services.Basket.Aplication.Settings;
using FreeCourse.Services.Basket.Persistence.Contexts;
using FreeCourse.Services.Basket.Persistence.Repositories.BasketRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FreeCourse.Services.Basket.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddBasketPersistenceService(this IServiceCollection services)
        {
            services.AddSingleton<RedisRepositoryContext>(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisSetting>>().Value;
                var redis = new RedisRepositoryContext(redisSettings.Host, redisSettings.Port);
                redis.Connect();
                return redis;
            });
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            return services;
        }
    }
}
