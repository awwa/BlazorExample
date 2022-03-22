using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDel", "Name", "Password", "Role" },
                values: new object[] { 2, "deleted@hogeblazor", false, "削除済みユーザー", "", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDel", "Name", "Password", "Role" },
                values: new object[] { 3, "user@hogeblazor", false, "一般ユーザー", "", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDel", "Name", "Password", "Role" },
                values: new object[] { 4, "guest@hogeblazor", false, "ゲストユーザー", "", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
