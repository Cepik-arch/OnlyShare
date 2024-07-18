using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class boolForAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("38805970-79af-4042-b61a-fed4f57daa0b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9264a739-6dfc-4450-bf99-23ae9afae7cb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f8354200-2861-4aec-a0de-5dfe80ba905b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("4d035467-89c7-4351-9332-902ddb15dc74"), new DateTime(2023, 4, 24, 12, 59, 8, 338, DateTimeKind.Local).AddTicks(3208), "Weather 3", 40 },
                    { new Guid("936eb672-eb9f-4d6d-a58b-ad14d678f514"), new DateTime(2022, 4, 24, 12, 59, 8, 338, DateTimeKind.Local).AddTicks(3196), "Weather 2", 35 },
                    { new Guid("a3e0ccf9-d2cd-425e-82fa-85ad8e4bc8ce"), new DateTime(2021, 4, 24, 12, 59, 8, 338, DateTimeKind.Local).AddTicks(3128), "Weather 1", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4d035467-89c7-4351-9332-902ddb15dc74"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("936eb672-eb9f-4d6d-a58b-ad14d678f514"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a3e0ccf9-d2cd-425e-82fa-85ad8e4bc8ce"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("38805970-79af-4042-b61a-fed4f57daa0b"), new DateTime(2022, 4, 16, 13, 54, 10, 330, DateTimeKind.Local).AddTicks(8037), "Weather 2", 35 },
                    { new Guid("9264a739-6dfc-4450-bf99-23ae9afae7cb"), new DateTime(2023, 4, 16, 13, 54, 10, 330, DateTimeKind.Local).AddTicks(8068), "Weather 3", 40 },
                    { new Guid("f8354200-2861-4aec-a0de-5dfe80ba905b"), new DateTime(2021, 4, 16, 13, 54, 10, 330, DateTimeKind.Local).AddTicks(7889), "Weather 1", 30 }
                });
        }
    }
}
