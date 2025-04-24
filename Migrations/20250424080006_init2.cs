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
                keyValue: "6b844442-c7f2-4f34-b8c0-00ee22e5a087");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd25f759-2d64-41cd-a551-f376da768792");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2b3a98af-282c-4f0e-be9c-a743f84e1115", 0, "e8bde6ab-b199-4ae8-9583-527356d6c0db", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "d43f2ddf-b563-4fd8-849b-7994f326c210", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "afc567ea-1801-4a43-97ba-970e09923dee", 0, "aae41441-695c-43b4-9d6e-fb644d9f9d4b", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c4079a37-778a-4110-800e-f5e2db489b1e", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b3a98af-282c-4f0e-be9c-a743f84e1115");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc567ea-1801-4a43-97ba-970e09923dee");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b844442-c7f2-4f34-b8c0-00ee22e5a087", 0, "991958e6-88ad-491b-9e22-9213e48e3aec", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "745ef391-ab6c-4049-a542-c2e7aeb20175", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd25f759-2d64-41cd-a551-f376da768792", 0, "274f703d-251b-47c6-a6e1-42bc0d6c7894", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "9c9df73e-8b4b-4614-a2af-5a77b05f0716", false, "Admin" });
        }
    }
}
