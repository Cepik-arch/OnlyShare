using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6fb5cde3-0108-4232-8ee3-608638ac828a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e102357c-2991-44e4-8b1d-885a240c9bba"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("fc9173da-f3d5-4610-92fe-197c92ef3e9f"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6fb5cde3-0108-4232-8ee3-608638ac828a"), new DateTime(2023, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1483), "Weather 3", 40 },
                    { new Guid("e102357c-2991-44e4-8b1d-885a240c9bba"), new DateTime(2021, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1402), "Weather 1", 30 },
                    { new Guid("fc9173da-f3d5-4610-92fe-197c92ef3e9f"), new DateTime(2022, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1471), "Weather 2", 35 }
                });
        }
    }
}
