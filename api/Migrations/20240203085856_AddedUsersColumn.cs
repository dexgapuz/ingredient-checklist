using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsersColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Recipes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Ingredients",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "MyProperty");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Recipes",
                newName: "MyProperty");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Ingredients",
                newName: "MyProperty");
        }
    }
}
