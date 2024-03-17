using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burger.REPO.Migrations
{
    public partial class cartAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Hamburger",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Extras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ByProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CartId",
                table: "Menus",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamburger_CartId",
                table: "Hamburger",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_CartId",
                table: "Extras",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ByProducts_CartId",
                table: "ByProducts",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ByProducts_Carts_CartId",
                table: "ByProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Carts_CartId",
                table: "Extras",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamburger_Carts_CartId",
                table: "Hamburger",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Carts_CartId",
                table: "Menus",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ByProducts_Carts_CartId",
                table: "ByProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Carts_CartId",
                table: "Extras");

            migrationBuilder.DropForeignKey(
                name: "FK_Hamburger_Carts_CartId",
                table: "Hamburger");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Carts_CartId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CartId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Hamburger_CartId",
                table: "Hamburger");

            migrationBuilder.DropIndex(
                name: "IX_Extras_CartId",
                table: "Extras");

            migrationBuilder.DropIndex(
                name: "IX_ByProducts_CartId",
                table: "ByProducts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Hamburger");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ByProducts");
        }
    }
}
