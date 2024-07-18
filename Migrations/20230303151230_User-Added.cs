using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class UserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("715ffda0-e8cc-425a-971c-5b65c9264b7d"), new DateTime(2022, 3, 3, 16, 12, 30, 174, DateTimeKind.Local).AddTicks(9548), "Weather 2", 35 },
                    { new Guid("b2f64002-e4e7-4767-b9f4-9afa0a0f5968"), new DateTime(2023, 3, 3, 16, 12, 30, 174, DateTimeKind.Local).AddTicks(9577), "Weather 3", 40 },
                    { new Guid("db904dc4-93f3-41b2-93e9-1c8f001cf288"), new DateTime(2021, 3, 3, 16, 12, 30, 174, DateTimeKind.Local).AddTicks(9410), "Weather 1", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("715ffda0-e8cc-425a-971c-5b65c9264b7d"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("b2f64002-e4e7-4767-b9f4-9afa0a0f5968"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("db904dc4-93f3-41b2-93e9-1c8f001cf288"));

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
    }
}
