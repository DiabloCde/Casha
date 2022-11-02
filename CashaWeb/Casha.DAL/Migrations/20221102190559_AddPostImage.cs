using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Casha.DAL.Migrations
{
    public partial class AddPostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostImageUrl",
                table: "Posts");
        }
    }
}
