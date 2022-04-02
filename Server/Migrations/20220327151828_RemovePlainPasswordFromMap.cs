using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogeBlazor.Server.Migrations
{
    public partial class RemovePlainPasswordFromMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlainPassword",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "$2a$05$qE7Eca3EjxBa7/Cn22HW1OS3J2/VzsGlt9UKN.NqVuSFIGXiFLa0y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "HashedPassword",
                value: "$2a$05$0J8WPb6Gm2FwHwCm.7t5uOvimqDdBnR71JWXWhYbDTlZwD5bq346W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "HashedPassword",
                value: "$2a$05$NNlUWqtYhTJOd2byiDZbgeNm7DAwD0/YqXeUcR6ZfzFYGeq2LEN3O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "HashedPassword",
                value: "$2a$05$Ecq42JLRUHQExPXKSbYPtOlOxjdWz5ca38qLxHKHLhJwjEqbs2Rwm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "PlainPassword",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "PlainPassword" },
                values: new object[] { "$2a$05$y.VdWcKh4v2Gra.OPm2kIOq7Amodbvdu9N.y9bqDKeraB7iQTz74i", "password" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "PlainPassword" },
                values: new object[] { "$2a$05$GbWq51BeZlOAxyfH9Owm0utphSAmaFP1FpiLokAoUylA0BwiWDWu2", "password" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "PlainPassword" },
                values: new object[] { "$2a$05$EiWml5rqdxP7fUXF9nwzju0O4JSdZLKfugfLWvRq9RMw2WD1lVRe.", "password" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "PlainPassword" },
                values: new object[] { "$2a$05$QVrx8L5If.RhjBInzp2/AORoILF7R.IRXZCUYyrxM3JokrZrrT652", "password" });
        }
    }
}
