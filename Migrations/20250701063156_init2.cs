using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c3d6acd-d4f0-4a31-ac24-6dd36bf175d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b32aded8-d274-4ff1-a246-9ca729d87441");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0de3979a-7057-4feb-a9db-b51ddd6417d9", 0, "2f72d0be-ea51-4b2b-8537-6ec25de5f0dc", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "ceccbaba-5f9d-4b4e-9168-1dfcd766c420", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1681d26a-e504-444e-b741-2c15312c5e8f", 0, "48e040d8-8b21-4cf6-ae27-987fad18d7b5", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "0b3b5a98-70fa-4bd9-962e-fda9767e13cb", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0de3979a-7057-4feb-a9db-b51ddd6417d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1681d26a-e504-444e-b741-2c15312c5e8f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c3d6acd-d4f0-4a31-ac24-6dd36bf175d7", 0, "2efd4750-2c01-4372-9456-67f043379f5f", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "a24beda6-05e7-4b14-bd0b-5dfed4a6914c", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b32aded8-d274-4ff1-a246-9ca729d87441", 0, "0bf0c32c-c59c-415c-999c-f88bd1a13d44", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "d03946c7-93c6-4901-85a3-130e358521f5", false, "User" });
        }
    }
}
