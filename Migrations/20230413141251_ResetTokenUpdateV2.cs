using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class ResetTokenUpdateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("458b9889-1160-4366-9c4a-04b138179f9d"), new DateTime(2023, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9228), "Weather 3", 40 },
                    { new Guid("652bfda5-a326-42af-b88f-d7d57c3e3480"), new DateTime(2022, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9217), "Weather 2", 35 },
                    { new Guid("9d9892d9-91b1-496d-bfab-fac7a6b12c73"), new DateTime(2021, 4, 13, 16, 12, 51, 613, DateTimeKind.Local).AddTicks(9136), "Weather 1", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
