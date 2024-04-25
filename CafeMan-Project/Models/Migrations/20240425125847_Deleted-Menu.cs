using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMan_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class DeletedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edibles_Cafes_CafeId",
                table: "Edibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Edibles_Menus_MenuId",
                table: "Edibles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Edibles_MenuId",
                table: "Edibles");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Edibles");

            migrationBuilder.AlterColumn<int>(
                name: "CafeId",
                table: "Edibles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Edibles_Cafes_CafeId",
                table: "Edibles",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "CafeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edibles_Cafes_CafeId",
                table: "Edibles");

            migrationBuilder.AlterColumn<int>(
                name: "CafeId",
                table: "Edibles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Edibles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeId = table.Column<int>(type: "int", nullable: false),
                    EdiblesId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Edibles_MenuId",
                table: "Edibles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CafeId",
                table: "Menus",
                column: "CafeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Edibles_Cafes_CafeId",
                table: "Edibles",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "CafeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edibles_Menus_MenuId",
                table: "Edibles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
