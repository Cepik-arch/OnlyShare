using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class boolv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("2c01b074-65eb-4714-8848-7df810e463dc"), new DateTime(2021, 4, 24, 13, 0, 31, 89, DateTimeKind.Local).AddTicks(3240), "Weather 1", 30 },
                    { new Guid("91ceb416-d1aa-4559-9370-276600c63c21"), new DateTime(2022, 4, 24, 13, 0, 31, 89, DateTimeKind.Local).AddTicks(3304), "Weather 2", 35 },
                    { new Guid("da807a09-341f-4039-b218-0c59795223c1"), new DateTime(2023, 4, 24, 13, 0, 31, 89, DateTimeKind.Local).AddTicks(3318), "Weather 3", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("2c01b074-65eb-4714-8848-7df810e463dc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("91ceb416-d1aa-4559-9370-276600c63c21"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("da807a09-341f-4039-b218-0c59795223c1"));

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
    }
}
