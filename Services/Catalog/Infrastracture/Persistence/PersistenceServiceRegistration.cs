﻿using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Application.Services.Repositories.CourseRepository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.CategoryRepository;
using Persistence.Repositories.CourseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICourseReadRepository, CourseReadRepository>();
            services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
            return services;
        }
    }
}
