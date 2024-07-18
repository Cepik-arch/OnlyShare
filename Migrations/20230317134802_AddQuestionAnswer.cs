using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("bf459a92-b5f3-43cb-aed6-7e6328d1bd71"), new DateTime(2023, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2811), "Weather 3", 40 },
                    { new Guid("d96ccd15-c4cf-4300-9e9b-1b06e26ba4e8"), new DateTime(2022, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2756), "Weather 2", 35 },
                    { new Guid("dcdb4779-fc27-4ff0-bec6-8536ddf581f9"), new DateTime(2021, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2599), "Weather 1", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("bf459a92-b5f3-43cb-aed6-7e6328d1bd71"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d96ccd15-c4cf-4300-9e9b-1b06e26ba4e8"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("dcdb4779-fc27-4ff0-bec6-8536ddf581f9"));

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
    }
}
