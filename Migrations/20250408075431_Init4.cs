using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c1bc1849-2cf6-4fb2-a175-535e260c2c59", 0, "ca842e98-dc05-4a40-b54e-ae8c9ebb5ae0", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5831f04b-45f5-4064-8e8f-b4c502f42e4a", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7032843-1dee-4133-bccb-f9dc3423844e", 0, "0e4d208b-6840-436c-8884-8527c3917890", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "3c0cf45c-6cc8-4776-9a97-d26169c30a49", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1bc1849-2cf6-4fb2-a175-535e260c2c59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7032843-1dee-4133-bccb-f9dc3423844e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02198141-cd89-4863-b1c4-c23a032e81d9", 0, "e9e19738-0e70-4f75-ba42-dc6a6621e7c0", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "f022d6dc-105d-472f-8d14-10f2a31bfa08", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "604e973f-779d-40ae-8ece-0e9a4f747f63", 0, "abfa1f28-5ead-49ff-87fa-fdd4a320498a", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "66eab966-43cf-43f8-9ad9-4a734cd8e6de", false, "Admin" });
        }
    }
}
