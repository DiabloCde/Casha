using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Casha.DAL.Migrations
{
    public partial class AddedUnitToUserProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "UserProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f21f28-242f-4857-9253-1b9806ac241a", "AQAAAAEAACcQAAAAEKTm7nZGgqeKpE33CIeZjrB1yMqibaN2TESAtD1loXD+/3DDH2l9vtiiqZ3uz9OXBg==", "267da887-a771-4070-833d-442aee220f7d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UserProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a593ddb-abaa-418d-89ad-56366e8cebba", "AQAAAAEAACcQAAAAECrubOlwsbAqioDfrp6R3iCtmmWkypW24pVfwxbOXrLwBkl5Mb1P/ovlhiyTGw3UAw==", "b126b7f4-ab32-431b-8c1e-cf7b85f82baf" });
        }
    }
}
