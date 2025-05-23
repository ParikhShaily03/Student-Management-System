using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class UniqueEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "642ae505-0a32-4db1-91b3-842ae1f06d48", 0, "597beb5e-a42d-449e-8d5f-2136d2ee5ce6", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "d07b6f4f-0fc4-4f8b-b5ce-f0e4cec511cb", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7192cd21-e95f-4bd8-825d-d6acfd2f39f4", 0, "f5350671-4861-43b2-a4d9-eb29d0e140c0", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "53c5e451-8956-4484-963a-fe5851770e8d", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "642ae505-0a32-4db1-91b3-842ae1f06d48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7192cd21-e95f-4bd8-825d-d6acfd2f39f4");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtpExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
