using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burger.REPO.Migrations
{
    public partial class fix_shopping_cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ShoppingCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
