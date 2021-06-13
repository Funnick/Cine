using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsPrice",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "PointsPrice",
                table: "Show",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Show",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsPrice",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Show");

            migrationBuilder.AddColumn<int>(
                name: "PointsPrice",
                table: "Movie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
