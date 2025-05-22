using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class AddPasswordResetToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a432750-c441-4354-973a-5e35f0b0c9c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86c80133-c7f4-40fc-8fa3-86dc09f50e4c");

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d4db935-d2c4-4dfe-be58-e1dd2af8c028", 0, "6d2d19ee-3679-4ccc-9245-7aac92211e23", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "ddb632d6-11f7-436b-831b-460898395b04", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d50be32-8165-4635-88a9-b9e88b3fe0df", 0, "717097ee-f70d-45fe-9fa6-16c493fe773b", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "95912518-ba2e-484a-801f-17ff284af6f5", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d4db935-d2c4-4dfe-be58-e1dd2af8c028");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d50be32-8165-4635-88a9-b9e88b3fe0df");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a432750-c441-4354-973a-5e35f0b0c9c6", 0, "2ad882e8-65e2-4259-9fb4-a64177c77dc7", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "55f9a917-4979-4dbd-9077-3dc3ef94e84f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86c80133-c7f4-40fc-8fa3-86dc09f50e4c", 0, "10d1c025-cc5c-44df-a73b-f30b0d3910ef", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "1d1eba84-c814-4c05-87c2-870c417bcd15", false, "User" });
        }
    }
}
