using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "post");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "blog");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "post",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "post",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "post",
                newName: "post_id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                table: "post",
                newName: "IX_post_BlogId");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "blog",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blog",
                newName: "blog_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                table: "post",
                column: "post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                table: "blog",
                column: "blog_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_blog_BlogId",
                table: "post",
                column: "BlogId",
                principalTable: "blog",
                principalColumn: "blog_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_blog_BlogId",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                table: "blog");

            migrationBuilder.RenameTable(
                name: "post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "blog",
                newName: "Blogs");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "post_id",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_post_BlogId",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Blogs",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "blog_id",
                table: "Blogs",
                newName: "BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
