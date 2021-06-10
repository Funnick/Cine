using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class addingIdentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TheaterUserId",
                table: "TheaterMember",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TheaterMember_TheaterUserId",
                table: "TheaterMember",
                column: "TheaterUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterMember_AspNetUsers_TheaterUserId",
                table: "TheaterMember",
                column: "TheaterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheaterMember_AspNetUsers_TheaterUserId",
                table: "TheaterMember");

            migrationBuilder.DropIndex(
                name: "IX_TheaterMember_TheaterUserId",
                table: "TheaterMember");

            migrationBuilder.DropColumn(
                name: "TheaterUserId",
                table: "TheaterMember");
        }
    }
}
