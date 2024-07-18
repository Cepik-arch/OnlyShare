using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6152849e-715f-447a-a92f-37565454e28f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("80a79c4a-8b49-4f8e-a107-cbe8c4d0b643"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a7d89d05-fb30-424d-9e52-139b52dd1572"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("493b7418-6a3a-4377-99f6-8b30f2a557c2"), new DateTime(2023, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(95), "Weather 3", 40 },
                    { new Guid("71dc9a59-5d4e-4229-8ad5-ebd3d2f9cdeb"), new DateTime(2021, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(8), "Weather 1", 30 },
                    { new Guid("9993605d-e629-4282-b749-b625d5d7785c"), new DateTime(2022, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(82), "Weather 2", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("493b7418-6a3a-4377-99f6-8b30f2a557c2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("71dc9a59-5d4e-4229-8ad5-ebd3d2f9cdeb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9993605d-e629-4282-b749-b625d5d7785c"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("6152849e-715f-447a-a92f-37565454e28f"), new DateTime(2021, 4, 27, 14, 46, 19, 86, DateTimeKind.Local).AddTicks(428), "Weather 1", 30 },
                    { new Guid("80a79c4a-8b49-4f8e-a107-cbe8c4d0b643"), new DateTime(2023, 4, 27, 14, 46, 19, 86, DateTimeKind.Local).AddTicks(580), "Weather 3", 40 },
                    { new Guid("a7d89d05-fb30-424d-9e52-139b52dd1572"), new DateTime(2022, 4, 27, 14, 46, 19, 86, DateTimeKind.Local).AddTicks(554), "Weather 2", 35 }
                });
        }
    }
}
