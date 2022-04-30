using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Migrations
{
    public partial class AddWeatherForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b892aca-dc7c-44aa-9bb8-43ad0ed38f70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a78340f9-c829-4a4a-b378-4c7c6f04b314");

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "97cd2a9f-b406-437d-8d69-e77609d98d7f", "729508aa-0e38-44a8-b093-b11e4fac9d2a", "Administrator", "ADMINISTRATOR" },
                    { "e3c66569-7a52-4245-973a-dcd70d5df663", "47927173-307d-4678-99e9-fcd225b85b5b", "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "雨", 15 },
                    { 2, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "晴れのち曇", 18 },
                    { 3, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "晴", 22 },
                    { 4, new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "台風", 26 },
                    { 5, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "曇", 21 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97cd2a9f-b406-437d-8d69-e77609d98d7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c66569-7a52-4245-973a-dcd70d5df663");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b892aca-dc7c-44aa-9bb8-43ad0ed38f70", "d83ddb90-38e3-4f90-9129-ae294d55a2ed", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a78340f9-c829-4a4a-b378-4c7c6f04b314", "c5ceb352-1551-4a3f-93a0-53cd85ff9079", "Viewer", "VIEWER" });
        }
    }
}
