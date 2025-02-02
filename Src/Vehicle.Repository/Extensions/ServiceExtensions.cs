using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Vehicle.Repository.Options;
using Vehicle.Repository.Services;

namespace Vehicle.Repository.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, RepositoryOptions? options)
        {
            var connectionString = options?.ConnectionString;
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            return services;
        }
    }
}
