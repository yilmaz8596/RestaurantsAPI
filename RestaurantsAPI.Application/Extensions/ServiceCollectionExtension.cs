using Microsoft.Extensions.DependencyInjection;
using RestaurantsAPI.Application.Restaurants;
using FluentValidation;
using RestaurantsAPI.Application.Validators;




namespace RestaurantsAPI.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<RestaurantsService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
            services.AddValidatorsFromAssemblyContaining<CreateRestaurantDtoValidator>();
        }
    }
}
