using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactController.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRestoredPasswordInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RestoredPassword",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestoredPassword",
                table: "Users");
        }
    }
}
