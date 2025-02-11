using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Universe.Application.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Persistence.src.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddDbContext<Project_UniverseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDbString"),
            b => b.MigrationsAssembly(typeof(Project_UniverseDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IProject_UniverseDbContext>(provider =>
            provider.GetService<Project_UniverseDbContext>());
            return services;
        }
    }
}
