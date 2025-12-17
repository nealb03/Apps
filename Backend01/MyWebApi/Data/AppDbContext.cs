using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;
using System;

namespace MyWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User seed
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Password = "password1" },
                new User { UserId = 2, FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com", Password = "password2" },
                new User { UserId = 3, FirstName = "Carol", LastName = "Williams", Email = "carol@example.com", Password = "password3" },
                new User { UserId = 4, FirstName = "David", LastName = "Brown", Email = "david@example.com", Password = "password4" },
                new User { UserId = 5, FirstName = "Eve", LastName = "Davis", Email = "eve@example.com", Password = "password5" }
            );

            // Account seed
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, UserId = 1, AccountNumber = "10010001", AccountType = "Checking", Balance = 1000.00m },
                new Account { AccountId = 2, UserId = 2, AccountNumber = "10010002", AccountType = "Savings", Balance = 2500.50m },
                new Account { AccountId = 3, UserId = 3, AccountNumber = "10010003", AccountType = "Checking", Balance = 300.75m },
                new Account { AccountId = 4, UserId = 4, AccountNumber = "10010004", AccountType = "Savings", Balance = 4200.00m },
                new Account { AccountId = 5, UserId = 5, AccountNumber = "10010005", AccountType = "Checking", Balance = 150.00m }
            );

            // Transaction seed
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionId = 1, AccountId = 1, Amount = 200.00m, Type = "Deposit", Description = "Initial deposit", CreatedAt = DateTime.UtcNow },
                new Transaction { TransactionId = 2, AccountId = 2, Amount = 150.50m, Type = "Deposit", Description = "Salary deposit", CreatedAt = DateTime.UtcNow },
                new Transaction { TransactionId = 3, AccountId = 3, Amount = -50.25m, Type = "Withdrawal", Description = "ATM withdrawal", CreatedAt = DateTime.UtcNow },
                new Transaction { TransactionId = 4, AccountId = 4, Amount = 500.00m, Type = "Deposit", Description = "Bonus", CreatedAt = DateTime.UtcNow },
                new Transaction { TransactionId = 5, AccountId = 5, Amount = -25.00m, Type = "Withdrawal", Description = "Grocery", CreatedAt = DateTime.UtcNow }
            );

            // WeatherForecast seed using DateOnly
            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast { Id = 1, Date = DateOnly.FromDateTime(DateTime.Today), TemperatureC = 20, Summary = "Mild" },
                new WeatherForecast { Id = 2, Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), TemperatureC = 22, Summary = "Warm" },
                new WeatherForecast { Id = 3, Date = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), TemperatureC = 18, Summary = "Cool" },
                new WeatherForecast { Id = 4, Date = DateOnly.FromDateTime(DateTime.Today.AddDays(3)), TemperatureC = 25, Summary = "Hot" },
                new WeatherForecast { Id = 5, Date = DateOnly.FromDateTime(DateTime.Today.AddDays(4)), TemperatureC = 15, Summary = "Chilly" }
            );
        }
    }
}
