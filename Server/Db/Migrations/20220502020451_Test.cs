using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Db.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48535ff7-5454-4d04-aedd-26e655f5db40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e77ce4-4358-49bc-b478-493ea1d541f6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e244ceb-f35e-445b-8f8a-ac1d8a35d017", "a2898ca4-183f-4486-a9bb-81dc4ed5cde4", "Administrator", "ADMINISTRATOR" },
                    { "617bb7f9-087d-42f1-9173-17d68cf54719", "0ec2e517-05c7-4f9c-9f40-4517dbcfb01a", "Viewer", "VIEWER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "48535ff7-5454-4d04-aedd-26e655f5db40", "7d597c34-da4a-4995-b32d-ed92ac8641ff", "Viewer", "VIEWER" },
                    { "d3e77ce4-4358-49bc-b478-493ea1d541f6", "4841bc9a-93e4-49e6-8e78-d4ac4e8e7e02", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
