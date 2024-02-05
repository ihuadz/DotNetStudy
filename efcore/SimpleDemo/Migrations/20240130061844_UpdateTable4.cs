using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contents",
                table: "post",
                newName: "content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "post",
                newName: "contents");
        }
    }
}
