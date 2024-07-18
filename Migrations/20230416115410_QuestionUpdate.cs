using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class QuestionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("1e0ec726-20da-418e-a0a0-c3b64d9b593f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9c860ca1-0310-40ef-93a5-bde935e9296f"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c6cdb01b-fba4-49c0-b1ce-30b82a60679c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("1e0ec726-20da-418e-a0a0-c3b64d9b593f"), new DateTime(2022, 4, 16, 12, 40, 15, 529, DateTimeKind.Local).AddTicks(503), "Weather 2", 35 },
                    { new Guid("9c860ca1-0310-40ef-93a5-bde935e9296f"), new DateTime(2021, 4, 16, 12, 40, 15, 529, DateTimeKind.Local).AddTicks(378), "Weather 1", 30 },
                    { new Guid("c6cdb01b-fba4-49c0-b1ce-30b82a60679c"), new DateTime(2023, 4, 16, 12, 40, 15, 529, DateTimeKind.Local).AddTicks(531), "Weather 3", 40 }
                });
        }
    }
}
