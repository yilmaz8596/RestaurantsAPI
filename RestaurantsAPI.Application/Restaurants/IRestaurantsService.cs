using RestaurantsAPI.Application.Restaurants.DTOs;


namespace RestaurantsAPI.Application.Restaurants
{
   public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
        Task<RestaurantDto?> GetRestaurantByIdAsync(int id);
        Task<int> Create(CreateRestaurantDto createRestaurantDto);
    }
}
