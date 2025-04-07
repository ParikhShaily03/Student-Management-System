using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "02198141-cd89-4863-b1c4-c23a032e81d9", 0, "e9e19738-0e70-4f75-ba42-dc6a6621e7c0", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "f022d6dc-105d-472f-8d14-10f2a31bfa08", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "604e973f-779d-40ae-8ece-0e9a4f747f63", 0, "abfa1f28-5ead-49ff-87fa-fdd4a320498a", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "66eab966-43cf-43f8-9ad9-4a734cd8e6de", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02198141-cd89-4863-b1c4-c23a032e81d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "604e973f-779d-40ae-8ece-0e9a4f747f63");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84e68ed4-ab4a-423b-a62b-1caa7cc63707", 0, "78d739f0-0e95-4b39-be68-23e71089dd22", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "90e8e4c9-f05b-423c-959d-16b0ecba59e8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b48d7b8f-3573-4c60-a3d8-c39f3a7f9d46", 0, "2ffa9f42-d55a-420d-990a-ba5ef55a4438", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "81ddddd6-00ab-478b-b7ca-2fb141bfe84b", false, "User" });
        }
    }
}
