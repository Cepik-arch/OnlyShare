using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class VotesV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Answers_AnswerId",
                table: "UserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Answers_AnswerId1",
                table: "UserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Users_UserId",
                table: "UserVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote");

            migrationBuilder.DropIndex(
                name: "IX_UserVote_AnswerId1",
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

            migrationBuilder.DropColumn(
                name: "AnswerId1",
                table: "UserVote");

            migrationBuilder.RenameTable(
                name: "UserVote",
                newName: "UserVotes");

            migrationBuilder.RenameIndex(
                name: "IX_UserVote_AnswerId",
                table: "UserVotes",
                newName: "IX_UserVotes_AnswerId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerId",
                table: "UserVotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpvote",
                table: "UserVotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("66e79e40-99b0-4f00-91fc-6b5a90010dda"), new DateTime(2021, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(106), "Weather 1", 30 },
                    { new Guid("a3f082ae-0930-4f1f-a0ff-3a89ba9409cc"), new DateTime(2023, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(191), "Weather 3", 40 },
                    { new Guid("f2b339fc-5398-4e4a-994b-02be6d0d4de2"), new DateTime(2022, 4, 27, 18, 43, 58, 907, DateTimeKind.Local).AddTicks(178), "Weather 2", 35 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_Answers_AnswerId",
                table: "UserVotes",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_Answers_AnswerId",
                table: "UserVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes");

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

            migrationBuilder.DropColumn(
                name: "IsUpvote",
                table: "UserVotes");

            migrationBuilder.RenameTable(
                name: "UserVotes",
                newName: "UserVote");

            migrationBuilder.RenameIndex(
                name: "IX_UserVotes_AnswerId",
                table: "UserVote",
                newName: "IX_UserVote_AnswerId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerId",
                table: "UserVote",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerId1",
                table: "UserVote",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote",
                column: "Id");

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
                name: "IX_UserVote_AnswerId1",
                table: "UserVote",
                column: "AnswerId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_UserId",
                table: "UserVote",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Answers_AnswerId",
                table: "UserVote",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Answers_AnswerId1",
                table: "UserVote",
                column: "AnswerId1",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Users_UserId",
                table: "UserVote",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
