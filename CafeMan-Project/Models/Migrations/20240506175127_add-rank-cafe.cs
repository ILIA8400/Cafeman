using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMan_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class addrankcafe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Cafes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Cafes");
        }
    }
}
