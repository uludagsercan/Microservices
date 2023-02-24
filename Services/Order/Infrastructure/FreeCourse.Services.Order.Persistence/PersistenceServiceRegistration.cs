using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Services.Order.Persistence.Contexts;
using FreeCourse.Services.Order.Persistence.Repositories.OrderRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Services.Order.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderRepositoryContext>(opt =>
            {
                string? sqlServer = configuration.GetConnectionString("DefaultConnection");
                opt.UseSqlServer(sqlServer);
            });

            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            
            return services;
        }
    }
}
