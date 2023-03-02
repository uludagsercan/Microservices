using FreeCourse.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FreeCourse.Shared
{
    public static class SharedRegistration
    {
        public static IServiceCollection AddSharedService(this IServiceCollection services)
        {
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
