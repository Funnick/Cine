using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class ShowDiscountNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Discount_DiscountId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "Show",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Discount_DiscountId",
                table: "Show",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Discount_DiscountId",
                table: "Show");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "Show",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Discount_DiscountId",
                table: "Show",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
