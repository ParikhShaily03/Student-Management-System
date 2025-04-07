using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Logout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66ac5579-77a9-4617-a446-ebcb25db86f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8308eee0-9ab6-4dea-9c67-dca8657a19bc");

            migrationBuilder.CreateTable(
                name: "RevokedTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevokedTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84e68ed4-ab4a-423b-a62b-1caa7cc63707", 0, "78d739f0-0e95-4b39-be68-23e71089dd22", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "90e8e4c9-f05b-423c-959d-16b0ecba59e8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b48d7b8f-3573-4c60-a3d8-c39f3a7f9d46", 0, "2ffa9f42-d55a-420d-990a-ba5ef55a4438", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "81ddddd6-00ab-478b-b7ca-2fb141bfe84b", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevokedTokens");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84e68ed4-ab4a-423b-a62b-1caa7cc63707");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b48d7b8f-3573-4c60-a3d8-c39f3a7f9d46");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66ac5579-77a9-4617-a446-ebcb25db86f7", 0, "752ec899-2910-4d6d-9b63-0b89aed39f3c", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "7e3a3b6c-fb2f-49aa-ad23-b16a07336e61", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8308eee0-9ab6-4dea-9c67-dca8657a19bc", 0, "17a60d78-2f61-4507-81b1-45a386d9968d", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "bbd32bce-4231-4b3a-bee4-4764579db627", false, "User" });
        }
    }
}
