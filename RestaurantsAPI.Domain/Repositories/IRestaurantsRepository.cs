

using RestaurantsAPI.Domain.Entities;

namespace RestaurantsAPI.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetByIdAsync(int id);
        Task<int> AddAsync(Restaurant restaurant);
    }
}
