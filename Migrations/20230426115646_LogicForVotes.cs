using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class LogicForVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vote_Answers_AnswerId1",
                        column: x => x.AnswerId1,
                        principalTable: "Answers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("6fb5cde3-0108-4232-8ee3-608638ac828a"), new DateTime(2023, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1483), "Weather 3", 40 },
                    { new Guid("e102357c-2991-44e4-8b1d-885a240c9bba"), new DateTime(2021, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1402), "Weather 1", 30 },
                    { new Guid("fc9173da-f3d5-4610-92fe-197c92ef3e9f"), new DateTime(2022, 4, 26, 13, 56, 46, 510, DateTimeKind.Local).AddTicks(1471), "Weather 2", 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_AnswerId",
                table: "Vote",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_AnswerId1",
                table: "Vote",
                column: "AnswerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("6fb5cde3-0108-4232-8ee3-608638ac828a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("e102357c-2991-44e4-8b1d-885a240c9bba"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("fc9173da-f3d5-4610-92fe-197c92ef3e9f"));

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
    }
}
