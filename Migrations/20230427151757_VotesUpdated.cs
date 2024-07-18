using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("493b7418-6a3a-4377-99f6-8b30f2a557c2"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("71dc9a59-5d4e-4229-8ad5-ebd3d2f9cdeb"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("9993605d-e629-4282-b749-b625d5d7785c"));

            migrationBuilder.CreateTable(
                name: "UserVote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVote_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVote_Answers_AnswerId1",
                        column: x => x.AnswerId1,
                        principalTable: "Answers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("99ada259-7976-4d33-9d0a-55552197b2ae"), new DateTime(2022, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8971), "Weather 2", 35 },
                    { new Guid("e655d329-5e2e-49bd-8d6c-32a3aafcdefa"), new DateTime(2023, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8983), "Weather 3", 40 },
                    { new Guid("eb88cd47-3863-4e75-9474-40f170a6bde8"), new DateTime(2021, 4, 27, 17, 17, 57, 832, DateTimeKind.Local).AddTicks(8900), "Weather 1", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_AnswerId",
                table: "UserVote",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_AnswerId1",
                table: "UserVote",
                column: "AnswerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVote");

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

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("493b7418-6a3a-4377-99f6-8b30f2a557c2"), new DateTime(2023, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(95), "Weather 3", 40 },
                    { new Guid("71dc9a59-5d4e-4229-8ad5-ebd3d2f9cdeb"), new DateTime(2021, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(8), "Weather 1", 30 },
                    { new Guid("9993605d-e629-4282-b749-b625d5d7785c"), new DateTime(2022, 4, 27, 14, 50, 46, 643, DateTimeKind.Local).AddTicks(82), "Weather 2", 35 }
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
    }
}
