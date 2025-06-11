using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class AddNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "002b938b-a848-4d18-ac36-4c5cfdd3132e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a5a2e1e-7951-4301-acb0-3bcc804494ba");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b07d1f1-ef69-49f0-a6c1-0c8f57d955d2", 0, "2b6b85aa-b7bb-4e2e-8978-36b210e73b26", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "fb3f12a0-2496-4a53-ada2-37b6ebfef994", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d41a8cb2-b72f-45f8-99ab-451bcef042b0", 0, "00f5914b-5974-4996-a3ca-9391cf44ebe9", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "8f604205-bff4-4754-9955-e67459970373", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b07d1f1-ef69-49f0-a6c1-0c8f57d955d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d41a8cb2-b72f-45f8-99ab-451bcef042b0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "002b938b-a848-4d18-ac36-4c5cfdd3132e", 0, "92202bdf-dc16-4b1e-89db-78323b0a0998", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "229af894-fc70-4f22-831f-f451b5082eae", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a5a2e1e-7951-4301-acb0-3bcc804494ba", 0, "85792399-bef5-49c3-b71c-4ed7d974a75f", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "6f52b57d-ef14-4fed-bc44-9ddeec7bbe51", false, "User" });
        }
    }
}
