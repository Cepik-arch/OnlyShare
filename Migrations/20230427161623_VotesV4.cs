using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("99ada259-7976-4d33-9d0a-55552197b2ae"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e655d329-5e2e-49bd-8d6c-32a3aafcdefa"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("eb88cd47-3863-4e75-9474-40f170a6bde8"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("955c3d52-c3b8-454f-9496-1bed0898843b"), new DateTime(2022, 4, 27, 18, 16, 23, 777, DateTimeKind.Local).AddTicks(779), "Weather 2", 35 },
                    { new Guid("a2607857-08f9-4ea0-895d-fcffc4184952"), new DateTime(2023, 4, 27, 18, 16, 23, 777, DateTimeKind.Local).AddTicks(792), "Weather 3", 40 },
                    { new Guid("aeafc920-b939-4a6c-b487-89449c806b1f"), new DateTime(2021, 4, 27, 18, 16, 23, 777, DateTimeKind.Local).AddTicks(708), "Weather 1", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_UserId",
                table: "UserVote",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Users_UserId",
                table: "UserVote",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Users_UserId",
                table: "UserVote");

            migrationBuilder.DropIndex(
                name: "IX_UserVote_UserId",
                table: "UserVote");

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("955c3d52-c3b8-454f-9496-1bed0898843b"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("a2607857-08f9-4ea0-895d-fcffc4184952"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("aeafc920-b939-4a6c-b487-89449c806b1f"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("99ada259-7976-4d33-9d0a-55552197b2ae"), new DateTime(2022, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8971), "Weather 2", 35 },
                    { new Guid("e655d329-5e2e-49bd-8d6c-32a3aafcdefa"), new DateTime(2023, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8983), "Weather 3", 40 },
                    { new Guid("eb88cd47-3863-4e75-9474-40f170a6bde8"), new DateTime(2021, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8900), "Weather 1", 30 }
                });
        }
    }
}
