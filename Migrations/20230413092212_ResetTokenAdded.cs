using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class ResetTokenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("94efada1-a25c-4882-a543-31d7124fa60a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bc3f9590-f2f2-47a8-808a-5f12d0225716"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e35cefd9-aaa5-46b0-9969-296a13e26d16"));

            migrationBuilder.CreateTable(
                name: "ResetTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("304c3866-7370-404f-81c1-136fc99f6295"), new DateTime(2023, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5562), "Weather 3", 40 },
                    { new Guid("52248276-61c6-4a32-8dae-3d9697f4e7aa"), new DateTime(2021, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5479), "Weather 1", 30 },
                    { new Guid("d9d5696b-f40b-4c66-a67b-1014b5c6765b"), new DateTime(2022, 4, 13, 11, 22, 12, 104, DateTimeKind.Local).AddTicks(5550), "Weather 2", 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResetTokens_UserId",
                table: "ResetTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetTokens");

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

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("94efada1-a25c-4882-a543-31d7124fa60a"), new DateTime(2022, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3570), "Weather 2", 35 },
                    { new Guid("bc3f9590-f2f2-47a8-808a-5f12d0225716"), new DateTime(2021, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3438), "Weather 1", 30 },
                    { new Guid("e35cefd9-aaa5-46b0-9969-296a13e26d16"), new DateTime(2023, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3604), "Weather 3", 40 }
                });
        }
    }
}
