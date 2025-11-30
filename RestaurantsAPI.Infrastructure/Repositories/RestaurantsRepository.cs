using RestaurantsAPI.Domain.Entities;
using RestaurantsAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;


namespace RestaurantsAPI.Domain.Repositories
{
    public class RestaurantsRepository(AppDbContext appDbContext) : IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await appDbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await appDbContext.Restaurants.Include(u => u.Dishes) 
                .FirstOrDefaultAsync(r => r.Id == id);

            return restaurant;
        }

        public async Task<int> AddAsync(Restaurant restaurant)
        {
            await appDbContext.Restaurants.AddAsync(restaurant);
            await appDbContext.SaveChangesAsync();

            return restaurant.Id;

        }
    }
}
