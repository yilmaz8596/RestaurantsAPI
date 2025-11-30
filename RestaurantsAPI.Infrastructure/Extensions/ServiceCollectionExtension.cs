using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantsAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Infrastructure.Seeders;
using RestaurantsAPI.Domain.Repositories;

namespace RestaurantsAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantsAPIConnectionString");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        }
    }
}
