using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initPac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b60582ce-1d3e-43fb-8f8f-660be2078b4a", 0, "0d4c9d7f-24c4-414b-a48f-9c05d377b213", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "a4f13803-692f-4867-aede-62e91bb79a78", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f65c3aea-53a2-4b59-a656-54cf1f3e5d48", 0, "dfaf001e-3b5f-4799-a535-f729c94f0806", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "43c58869-e208-4961-8de5-5d91285c57d8", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b60582ce-1d3e-43fb-8f8f-660be2078b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f65c3aea-53a2-4b59-a656-54cf1f3e5d48");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09d84536-e697-4cd6-8876-49c477c9c9ce", 0, "892f72c6-f161-4b71-b8a6-a348d3d0a549", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "23768b81-8be2-4cba-b0c5-c83760fdd22c", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "24488a43-dfee-4410-ba2f-9e051d61d753", 0, "3154c47a-e9cc-4f47-aa99-9bbdec280219", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "9f4de602-820b-4a35-b15b-4dcf4b29ebbc", false, "User" });
        }
    }
}
