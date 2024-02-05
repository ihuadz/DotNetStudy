using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_blog_BlogId",
                table: "post");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "post",
                newName: "blog_id");

            migrationBuilder.RenameIndex(
                name: "IX_post_BlogId",
                table: "post",
                newName: "IX_post_blog_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_blog_blog_id",
                table: "post",
                column: "blog_id",
                principalTable: "blog",
                principalColumn: "blog_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_blog_blog_id",
                table: "post");

            migrationBuilder.RenameColumn(
                name: "blog_id",
                table: "post",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_post_blog_id",
                table: "post",
                newName: "IX_post_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_post_blog_BlogId",
                table: "post",
                column: "BlogId",
                principalTable: "blog",
                principalColumn: "blog_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
