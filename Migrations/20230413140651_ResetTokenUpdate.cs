using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class ResetTokenUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("304c3866-7370-404f-81c1-136fc99f6295"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("52248276-61c6-4a32-8dae-3d9697f4e7aa"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d9d5696b-f40b-4c66-a67b-1014b5c6765b"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ResetTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("1f96e9b2-5dc1-4b86-9061-a062b216df36"), new DateTime(2021, 4, 13, 16, 6, 51, 516, DateTimeKind.Local).AddTicks(9178), "Weather 1", 30 },
                    { new Guid("ab8098d3-fcac-4a3e-bead-1ee2667184ce"), new DateTime(2022, 4, 13, 16, 6, 51, 516, DateTimeKind.Local).AddTicks(9246), "Weather 2", 35 },
                    { new Guid("cb023550-7908-404f-88b5-7e5b072d9d91"), new DateTime(2023, 4, 13, 16, 6, 51, 516, DateTimeKind.Local).AddTicks(9258), "Weather 3", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1f96e9b2-5dc1-4b86-9061-a062b216df36"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("ab8098d3-fcac-4a3e-bead-1ee2667184ce"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("cb023550-7908-404f-88b5-7e5b072d9d91"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ResetTokens");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("304c3866-7370-404f-81c1-136fc99f6295"), new DateTime(2023, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5562), "Weather 3", 40 },
                    { new Guid("52248276-61c6-4a32-8dae-3d9697f4e7aa"), new DateTime(2021, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5479), "Weather 1", 30 },
                    { new Guid("d9d5696b-f40b-4c66-a67b-1014b5c6765b"), new DateTime(2022, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5550), "Weather 2", 35 }
                });
        }
    }
}
