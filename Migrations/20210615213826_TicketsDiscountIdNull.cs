using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class TicketsDiscountIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Discount_DiscountId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "Ticket",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Discount_DiscountId",
                table: "Ticket",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Discount_DiscountId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "Ticket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Discount_DiscountId",
                table: "Ticket",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
