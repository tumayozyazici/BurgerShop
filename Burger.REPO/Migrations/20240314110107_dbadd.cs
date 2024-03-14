using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burger.REPO.Migrations
{
    public partial class dbadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Extras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Extras");
        }
    }
}
