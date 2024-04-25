using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMan_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCafeOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    CafeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CafeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<int>(type: "int", nullable: true),
                    Tel = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.CafeId);
                    table.ForeignKey(
                        name: "FK_Cafes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CafeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "CafeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdiblesId = table.Column<int>(type: "int", nullable: false),
                    CafeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "CafeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edibles",
                columns: table => new
                {
                    EdiblesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsFood = table.Column<bool>(type: "bit", nullable: true),
                    IsDrink = table.Column<bool>(type: "bit", nullable: true),
                    IsDessert = table.Column<bool>(type: "bit", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CafeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edibles", x => x.EdiblesId);
                    table.ForeignKey(
                        name: "FK_Edibles_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "CafeId");
                    table.ForeignKey(
                        name: "FK_Edibles_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_UserId",
                table: "Cafes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CafeId",
                table: "Comments",
                column: "CafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Edibles_CafeId",
                table: "Edibles",
                column: "CafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edibles_MenuId",
                table: "Edibles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CafeId",
                table: "Menus",
                column: "CafeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Edibles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
