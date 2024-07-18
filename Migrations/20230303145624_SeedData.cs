using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("7a73aefe-3140-4ff1-b984-e7075bbda300"), new DateTime(2021, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(7987), "Weather 1", 30 },
                    { new Guid("86c2428c-8d82-433d-a047-70a96a35baee"), new DateTime(2022, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(8129), "Weather 2", 35 },
                    { new Guid("e1dfa72c-d41f-4e15-be5c-3eea7f44f395"), new DateTime(2023, 3, 3, 15, 56, 24, 189, DateTimeKind.Local).AddTicks(8158), "Weather 3", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7a73aefe-3140-4ff1-b984-e7075bbda300"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("86c2428c-8d82-433d-a047-70a96a35baee"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e1dfa72c-d41f-4e15-be5c-3eea7f44f395"));
        }
    }
}
