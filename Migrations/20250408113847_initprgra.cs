using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initprgra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2ed211b5-9aa1-4007-94c7-14887f7ea60a", 0, "312ee4bf-49b4-497e-8e5d-ab8630aae1b6", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "545accb0-7e1a-4b39-9654-f097934698ec", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9876360-b589-43f6-9f5a-44ac468d2f36", 0, "5adeccf2-786e-4186-b446-c291b44aa3fe", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "aae30ea9-4cd8-4d1f-b638-034f4d01d99c", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ed211b5-9aa1-4007-94c7-14887f7ea60a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9876360-b589-43f6-9f5a-44ac468d2f36");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "645427a7-dd04-4efa-8d68-28b65d700e28", 0, "0920e72d-7d34-473b-88d0-55af14a9ba90", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "2a9e68a0-47de-4360-a09d-e6dc49660231", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bae8cdfe-9041-4a43-a9c3-420372754f7d", 0, "1a91617e-1197-4a4c-b3e0-24dadfd28c5c", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5452f2d8-6672-473a-8909-bf4667e591d8", false, "User" });
        }
    }
}
