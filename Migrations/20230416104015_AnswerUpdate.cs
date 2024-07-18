using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class AnswerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("458b9889-1160-4366-9c4a-04b138179f9d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("652bfda5-a326-42af-b88f-d7d57c3e3480"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9d9892d9-91b1-496d-bfab-fac7a6b12c73"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Answers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("458b9889-1160-4366-9c4a-04b138179f9d"), new DateTime(2023, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9228), "Weather 3", 40 },
                    { new Guid("652bfda5-a326-42af-b88f-d7d57c3e3480"), new DateTime(2022, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9217), "Weather 2", 35 },
                    { new Guid("9d9892d9-91b1-496d-bfab-fac7a6b12c73"), new DateTime(2021, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9136), "Weather 1", 30 }
                });
        }
    }
}
