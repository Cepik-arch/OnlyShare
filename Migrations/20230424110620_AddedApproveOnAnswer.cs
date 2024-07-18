using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class AddedApproveOnAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("18257791-d312-4592-b95b-40537c889d6e"), new DateTime(2023, 4, 24, 13, 6, 20, 326, DateTimeKind.Local).AddTicks(7690), "Weather 3", 40 },
                    { new Guid("473370d1-1f8d-4d78-bf4e-e7556971f17c"), new DateTime(2022, 4, 24, 13, 6, 20, 326, DateTimeKind.Local).AddTicks(7679), "Weather 2", 35 },
                    { new Guid("94364328-bc1d-4eb6-b842-e9b6a0ab321d"), new DateTime(2021, 4, 24, 13, 6, 20, 326, DateTimeKind.Local).AddTicks(7609), "Weather 1", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("18257791-d312-4592-b95b-40537c889d6e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("473370d1-1f8d-4d78-bf4e-e7556971f17c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("94364328-bc1d-4eb6-b842-e9b6a0ab321d"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Answers");

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
    }
}
