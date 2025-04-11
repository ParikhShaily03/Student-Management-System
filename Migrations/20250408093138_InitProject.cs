using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class InitProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "645427a7-dd04-4efa-8d68-28b65d700e28", 0, "0920e72d-7d34-473b-88d0-55af14a9ba90", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "2a9e68a0-47de-4360-a09d-e6dc49660231", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bae8cdfe-9041-4a43-a9c3-420372754f7d", 0, "1a91617e-1197-4a4c-b3e0-24dadfd28c5c", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5452f2d8-6672-473a-8909-bf4667e591d8", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "645427a7-dd04-4efa-8d68-28b65d700e28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bae8cdfe-9041-4a43-a9c3-420372754f7d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1bc1849-2cf6-4fb2-a175-535e260c2c59", 0, "ca842e98-dc05-4a40-b54e-ae8c9ebb5ae0", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5831f04b-45f5-4064-8e8f-b4c502f42e4a", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7032843-1dee-4133-bccb-f9dc3423844e", 0, "0e4d208b-6840-436c-8884-8527c3917890", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "3c0cf45c-6cc8-4776-9a97-d26169c30a49", false, "Admin" });
        }
    }
}
