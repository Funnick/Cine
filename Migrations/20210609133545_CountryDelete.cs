using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Migrations
{
    public partial class CountryDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }
    }
}
