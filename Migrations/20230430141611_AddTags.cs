using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("66e79e40-99b0-4f00-91fc-6b5a90010dda"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a3f082ae-0930-4f1f-a0ff-3a89ba9409cc"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f2b339fc-5398-4e4a-994b-02be6d0d4de2"));

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("0f406b6a-3782-4bbf-9179-1736ccd71101"), new DateTime(2023, 4, 30, 16, 16, 11, 74, DateTimeKind.Local).AddTicks(5060), "Weather 3", 40 },
                    { new Guid("4a4de19b-fdcd-42b0-8cf4-0d927cc3e4d0"), new DateTime(2021, 4, 30, 16, 16, 11, 74, DateTimeKind.Local).AddTicks(4876), "Weather 1", 30 },
                    { new Guid("c0ab07cd-7a35-42c9-8d5c-178d77dfa9a4"), new DateTime(2022, 4, 30, 16, 16, 11, 74, DateTimeKind.Local).AddTicks(5022), "Weather 2", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0f406b6a-3782-4bbf-9179-1736ccd71101"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("4a4de19b-fdcd-42b0-8cf4-0d927cc3e4d0"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("c0ab07cd-7a35-42c9-8d5c-178d77dfa9a4"));

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("66e79e40-99b0-4f00-91fc-6b5a90010dda"), new DateTime(2021, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(106), "Weather 1", 30 },
                    { new Guid("a3f082ae-0930-4f1f-a0ff-3a89ba9409cc"), new DateTime(2023, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(191), "Weather 3", 40 },
                    { new Guid("f2b339fc-5398-4e4a-994b-02be6d0d4de2"), new DateTime(2022, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(178), "Weather 2", 35 }
                });
        }
    }
}
