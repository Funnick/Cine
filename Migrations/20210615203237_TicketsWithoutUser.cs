using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class TicketsWithoutUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TheaterUserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TheaterUserId",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TheaterUserId",
                table: "Ticket",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TheaterUserId",
                table: "Ticket",
                column: "TheaterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket",
                column: "TheaterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
