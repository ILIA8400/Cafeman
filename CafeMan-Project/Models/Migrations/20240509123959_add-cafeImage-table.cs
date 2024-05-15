using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMan_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class addcafeImagetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Cafes");

            migrationBuilder.CreateTable(
                name: "CafeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CafeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CafeImages_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "CafeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CafeImages_CafeId",
                table: "CafeImages",
                column: "CafeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CafeImages");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Cafes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
