using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice", "Smith", "password1" },
                    { 2, "bob@example.com", "Bob", "Johnson", "password2" },
                    { 3, "carol@example.com", "Carol", "Williams", "password3" },
                    { 4, "david@example.com", "David", "Brown", "password4" },
                    { 5, "eve@example.com", "Eve", "Davis", "password5" }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 10, 8), "Mild", 20 },
                    { 2, new DateOnly(2025, 10, 9), "Warm", 22 },
                    { 3, new DateOnly(2025, 10, 10), "Cool", 18 },
                    { 4, new DateOnly(2025, 10, 11), "Hot", 25 },
                    { 5, new DateOnly(2025, 10, 12), "Chilly", 15 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountNumber", "AccountType", "Balance", "UserId" },
                values: new object[,]
                {
                    { 1, "10010001", "Checking", 1000.00m, 1 },
                    { 2, "10010002", "Savings", 2500.50m, 2 },
                    { 3, "10010003", "Checking", 300.75m, 3 },
                    { 4, "10010004", "Savings", 4200.00m, 4 },
                    { 5, "10010005", "Checking", 150.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccountId", "Amount", "CreatedAt", "Description", "Type" },
                values: new object[,]
                {
                    { 1, 1, 200.00m, new DateTime(2025, 10, 8, 19, 14, 48, 933, DateTimeKind.Local).AddTicks(9891), "Initial deposit", "Deposit" },
                    { 2, 2, 150.50m, new DateTime(2025, 10, 8, 19, 14, 48, 934, DateTimeKind.Local).AddTicks(133), "Salary deposit", "Deposit" },
                    { 3, 3, -50.25m, new DateTime(2025, 10, 8, 19, 14, 48, 934, DateTimeKind.Local).AddTicks(136), "ATM withdrawal", "Withdrawal" },
                    { 4, 4, 500.00m, new DateTime(2025, 10, 8, 19, 14, 48, 934, DateTimeKind.Local).AddTicks(139), "Bonus", "Deposit" },
                    { 5, 5, -25.00m, new DateTime(2025, 10, 8, 19, 14, 48, 934, DateTimeKind.Local).AddTicks(141), "Grocery", "Withdrawal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);
        }
    }
}
