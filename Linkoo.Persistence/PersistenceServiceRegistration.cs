using Linkoo.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Linkoo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LinkooDbContext>(options=>{
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
    }
}