using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class PointsPriceandDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "TheaterUserId",
                table: "Ticket",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsPrice",
                table: "Movie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket",
                column: "TheaterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PointsPrice",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "TheaterUserId",
                table: "Ticket",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_TheaterUserId",
                table: "Ticket",
                column: "TheaterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
