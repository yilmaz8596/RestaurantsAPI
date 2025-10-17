
using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Domain.Entities;


namespace RestaurantsAPI.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Restaurant> Restaurants { get; set; } = default!;
        public DbSet<Dish> Dishes { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;

    }


}
