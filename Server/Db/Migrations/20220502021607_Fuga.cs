using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Db.Migrations
{
    public partial class Fuga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e244ceb-f35e-445b-8f8a-ac1d8a35d017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "617bb7f9-087d-42f1-9173-17d68cf54719");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "873ab360-3daa-429d-b74b-e33f6b64fbf9", "054609f1-db9a-40ff-9903-c8e5fe39fcb0", "Viewer", "VIEWER" },
                    { "eff5c347-1236-47e5-9dc9-4b824bc672cd", "7479cf62-98c9-4ea5-8390-97e2c6847a55", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873ab360-3daa-429d-b74b-e33f6b64fbf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff5c347-1236-47e5-9dc9-4b824bc672cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e244ceb-f35e-445b-8f8a-ac1d8a35d017", "a2898ca4-183f-4486-a9bb-81dc4ed5cde4", "Administrator", "ADMINISTRATOR" },
                    { "617bb7f9-087d-42f1-9173-17d68cf54719", "0ec2e517-05c7-4f9c-9f40-4517dbcfb01a", "Viewer", "VIEWER" }
                });
        }
    }
}
