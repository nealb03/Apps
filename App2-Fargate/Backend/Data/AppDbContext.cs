using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        // Optional: Comment out if you no longer need weather data
        // public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Keep this area clean, avoid seed data to ensure data always comes from live database

            /*
            // Example seed data (commented for production)
            // modelBuilder.Entity<User>().HasData(
            //     new User { UserId = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Password = "password1" },
            //     ...
            // );
            */
        }
    }
}