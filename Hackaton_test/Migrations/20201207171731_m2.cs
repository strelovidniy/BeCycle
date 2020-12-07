using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton_test.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poster_User_PosterUserForeignKey",
                table: "Poster");

            migrationBuilder.DropIndex(
                name: "IX_Poster_PosterUserForeignKey",
                table: "Poster");

            migrationBuilder.DropColumn(
                name: "PosterUserForeignKey",
                table: "Poster");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_UserId",
                table: "Poster",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_User_UserId",
                table: "Poster",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poster_User_UserId",
                table: "Poster");

            migrationBuilder.DropIndex(
                name: "IX_Poster_UserId",
                table: "Poster");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "User",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PosterUserForeignKey",
                table: "Poster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poster_PosterUserForeignKey",
                table: "Poster",
                column: "PosterUserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_User_PosterUserForeignKey",
                table: "Poster",
                column: "PosterUserForeignKey",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
