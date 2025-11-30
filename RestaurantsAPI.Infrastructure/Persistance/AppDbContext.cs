
using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Domain.Entities;


namespace RestaurantsAPI.Infrastructure.Persistance
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
             .OwnsOne(r => r.Address, a =>
             {
                 a.Property(addr => addr.City).HasColumnName("Address_City");
                 a.Property(addr => addr.Street).HasColumnName("Address_Street");
                 a.Property(addr => addr.PostalCode).HasColumnName("Address_PostalCode");
             });

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Restaurant> Restaurants { get; set; } = default!;
        public DbSet<Dish> Dishes { get; set; } = default!;

    }


}
