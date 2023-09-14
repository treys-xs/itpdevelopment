using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IProjectDbContext>(provider =>
                provider.GetService<ProjectDbContext>());

            return services;
        }
    }
}
