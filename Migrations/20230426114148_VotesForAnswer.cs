using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesForAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("2351bef0-0a73-4dcc-a9d3-b53498284948"), new DateTime(2022, 4, 26, 13, 41, 48, 355, DateTimeKind.Local).AddTicks(2291), "Weather 2", 35 },
                    { new Guid("2b5650cc-0149-4a5b-8992-2726ddf08f68"), new DateTime(2023, 4, 26, 13, 41, 48, 355, DateTimeKind.Local).AddTicks(2302), "Weather 3", 40 },
                    { new Guid("6cdc6989-ec57-40f7-8185-f87723425efe"), new DateTime(2021, 4, 26, 13, 41, 48, 355, DateTimeKind.Local).AddTicks(2227), "Weather 1", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("2351bef0-0a73-4dcc-a9d3-b53498284948"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("2b5650cc-0149-4a5b-8992-2726ddf08f68"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6cdc6989-ec57-40f7-8185-f87723425efe"));

            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Answers");

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
    }
}
