using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burger.REPO.Migrations
{
    public partial class add_shopping_cart : Migration
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

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartByProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ByProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartByProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartByProducts_ByProducts_ByProductId",
                        column: x => x.ByProductId,
                        principalTable: "ByProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartByProducts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartExtras_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartExtras_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartHamburgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamburgerId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartHamburgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartHamburgers_Hamburger_HamburgerId",
                        column: x => x.HamburgerId,
                        principalTable: "Hamburger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartHamburgers_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartMenus_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartByProducts_ByProductId",
                table: "ShoppingCartByProducts",
                column: "ByProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartByProducts_ShoppingCartId",
                table: "ShoppingCartByProducts",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartExtras_ExtraId",
                table: "ShoppingCartExtras",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartExtras_ShoppingCartId",
                table: "ShoppingCartExtras",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartHamburgers_HamburgerId",
                table: "ShoppingCartHamburgers",
                column: "HamburgerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartHamburgers_ShoppingCartId",
                table: "ShoppingCartHamburgers",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartMenus_MenuId",
                table: "ShoppingCartMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartMenus_ShoppingCartId",
                table: "ShoppingCartMenus",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId");

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

            migrationBuilder.DropTable(
                name: "ShoppingCartByProducts");

            migrationBuilder.DropTable(
                name: "ShoppingCartExtras");

            migrationBuilder.DropTable(
                name: "ShoppingCartHamburgers");

            migrationBuilder.DropTable(
                name: "ShoppingCartMenus");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

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
