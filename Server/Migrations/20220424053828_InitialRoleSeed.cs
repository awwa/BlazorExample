﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51eb3b84-c5e2-496d-8a86-5baa26f245a1", "934a692e-7d78-4e1b-ab04-b5fb3e9bde6f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1079f5e-7a04-4b26-9c03-b001a6425cc8", "726217f2-a58e-4fd1-b727-26fea3d3f3dd", "Viewer", "VIEWER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51eb3b84-c5e2-496d-8a86-5baa26f245a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1079f5e-7a04-4b26-9c03-b001a6425cc8");
        }
    }
}
