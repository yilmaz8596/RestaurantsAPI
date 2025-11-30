
using RestaurantsAPI.Infrastructure.Persistance;
using RestaurantsAPI.Domain.Entities;



namespace RestaurantsAPI.Infrastructure.Seeders
{
    public class RestaurantSeeder(AppDbContext appDbContext) : IRestaurantSeeder   
    {
        public async Task Seed()
        {
            if (await appDbContext.Database.CanConnectAsync())
            {
                if (!appDbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    appDbContext.Restaurants.AddRange(restaurants);
                    await appDbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "An American fast food restaurant",
                    ContactEmail = "kfc@kfc.com",
                    HasDelivery = true,
                    Dishes = [
                        new() {
                            Name = "Nashville Hot Chicken",
                            Description = "Spicy chicken (10 pcs.)",
                            Price = 10.30M,
                            KiloCalories = 900
                        },
                         new() {  Name = "Chicken Nuggets",
                            Description = "Chicken nuggets (5 pcs.)",
                            Price = 5.30M, 
                            KiloCalories = 500
                         }
                        ],
                    Address = new() {
                        City = "London",
                        Street = "Cork Str. 5",
                        PostalCode = "WC2N 5DU"
                    }
                },
                 new()
    {
        Name = "McDonald's",
        Category = "Fast Food",
        Description = "World's largest fast food restaurant chain",
        ContactEmail = "info@mcdonalds.com",
        HasDelivery = true,
        Dishes = [
            new() {
                Name = "Big Mac",
                Description = "Two all-beef patties, special sauce, lettuce, cheese",
                Price = 8.99M,
                KiloCalories = 700
            },
            new() {
                Name = "French Fries",
                Description = "Golden crispy fries (Large)",
                Price = 3.49M,
                KiloCalories = 510
            },
            new() {
                Name = "McFlurry Oreo",
                Description = "Vanilla soft serve with Oreo pieces",
                Price = 4.25M,
                KiloCalories = 340
            }
        ],
        Address = new() {
            City = "New York",
            Street = "Broadway 123",
            PostalCode = "10001"
                 }
        }
     ];
            return restaurants;
        }
    }
}

