using AFO.Application.Interfaces;
using AFO.Infrastructure.Persistence;
using AFO.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AFO.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AfoDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceContentRepository, ServiceContentRepository>();

            services.AddScoped<IRealizationRepository, RealizationRepository>();
            services.AddScoped<IRealizationImageRepository, RealizationImageRepository>();
            services.AddScoped<IAdvantageRepository, AdvantageRepository>();
            return services;
        }
    }
}
