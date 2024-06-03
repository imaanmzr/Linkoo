using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Persistence.DatabaseContext;
using Linkoo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Linkoo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LinkooDbContext>(options =>
          {
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          });

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LinkooDbContext>());

            return services;
        }

    }
}