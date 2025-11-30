using Microsoft.Extensions.Logging;
using RestaurantsAPI.Domain.Repositories;
using RestaurantsAPI.Application.Restaurants.DTOs;
using AutoMapper;
using RestaurantsAPI.Domain.Entities;



namespace RestaurantsAPI.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
        {
            logger.LogWarning("⚠️ GETTING ALL RESTAURANTS - THIS IS A TEST ⚠️");
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            logger.LogInformation("Retrieved {Count} restaurants", restaurants.Count());

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos!;
        }

        public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(id);
            logger.LogInformation("Retreived restaurant: {RestaurantName}", restaurant?.Name);

            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
            return restaurantDto;
        }

        public async Task<int> Create(CreateRestaurantDto createRestaurantDto)
        {
             var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
             var createdRestaurantId = await restaurantsRepository.AddAsync(restaurant);

             logger.LogInformation("Created restaurant: {RestaurantName}", restaurant.Name);

             return createdRestaurantId;

        }
    }
}
