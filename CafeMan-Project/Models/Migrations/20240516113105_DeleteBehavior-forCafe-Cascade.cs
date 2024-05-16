using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMan_Project.Models.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorforCafeCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_User_UsersId",
                table: "Cafes");

            migrationBuilder.AlterColumn<string>(
                name: "UsersId",
                table: "Cafes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_User_UsersId",
                table: "Cafes",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_User_UsersId",
                table: "Cafes");

            migrationBuilder.AlterColumn<string>(
                name: "UsersId",
                table: "Cafes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_User_UsersId",
                table: "Cafes",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
