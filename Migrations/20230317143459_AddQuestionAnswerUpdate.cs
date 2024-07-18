using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionAnswerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("94efada1-a25c-4882-a543-31d7124fa60a"), new DateTime(2022, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3570), "Weather 2", 35 },
                    { new Guid("bc3f9590-f2f2-47a8-808a-5f12d0225716"), new DateTime(2021, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3438), "Weather 1", 30 },
                    { new Guid("e35cefd9-aaa5-46b0-9969-296a13e26d16"), new DateTime(2023, 3, 17, 15, 34, 58, 913, DateTimeKind.Local).AddTicks(3604), "Weather 3", 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserId",
                table: "Answers");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Answers");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("bf459a92-b5f3-43cb-aed6-7e6328d1bd71"), new DateTime(2023, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2811), "Weather 3", 40 },
                    { new Guid("d96ccd15-c4cf-4300-9e9b-1b06e26ba4e8"), new DateTime(2022, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2756), "Weather 2", 35 },
                    { new Guid("dcdb4779-fc27-4ff0-bec6-8536ddf581f9"), new DateTime(2021, 3, 17, 14, 48, 2, 330, DateTimeKind.Local).AddTicks(2599), "Weather 1", 30 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
