using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "09d84536-e697-4cd6-8876-49c477c9c9ce", 0, "892f72c6-f161-4b71-b8a6-a348d3d0a549", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "23768b81-8be2-4cba-b0c5-c83760fdd22c", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "24488a43-dfee-4410-ba2f-9e051d61d753", 0, "3154c47a-e9cc-4f47-aa99-9bbdec280219", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "9f4de602-820b-4a35-b15b-4dcf4b29ebbc", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09d84536-e697-4cd6-8876-49c477c9c9ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24488a43-dfee-4410-ba2f-9e051d61d753");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2ed211b5-9aa1-4007-94c7-14887f7ea60a", 0, "312ee4bf-49b4-497e-8e5d-ab8630aae1b6", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "545accb0-7e1a-4b39-9654-f097934698ec", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9876360-b589-43f6-9f5a-44ac468d2f36", 0, "5adeccf2-786e-4186-b446-c291b44aa3fe", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "aae30ea9-4cd8-4d1f-b638-034f4d01d99c", false, "User" });
        }
    }
}
