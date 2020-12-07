using Microsoft.EntityFrameworkCore.Migrations;

namespace Hackaton_test.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poster_User_UserId",
                table: "Poster");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Poster",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_UserId",
                table: "Poster",
                newName: "IX_Poster_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_User_AuthorId",
                table: "Poster",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poster_User_AuthorId",
                table: "Poster");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Poster",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Poster_AuthorId",
                table: "Poster",
                newName: "IX_Poster_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_User_UserId",
                table: "Poster",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
