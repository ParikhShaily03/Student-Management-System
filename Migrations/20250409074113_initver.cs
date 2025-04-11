using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "37a300ce-735d-4265-8463-54accb1163b2", 0, "f00eb6ea-1cd3-4c04-bd3e-240926453834", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "7c807291-aaba-48af-ad98-bb4e1dab0a94", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de9fe56d-7661-4aea-b8d7-48183023928d", 0, "2fecf2f6-bb6d-4067-befe-03f4f7ae9991", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "4d56195f-2675-43bb-9e5b-9de925f251d1", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37a300ce-735d-4265-8463-54accb1163b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de9fe56d-7661-4aea-b8d7-48183023928d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b60582ce-1d3e-43fb-8f8f-660be2078b4a", 0, "0d4c9d7f-24c4-414b-a48f-9c05d377b213", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "a4f13803-692f-4867-aede-62e91bb79a78", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f65c3aea-53a2-4b59-a656-54cf1f3e5d48", 0, "dfaf001e-3b5f-4799-a535-f729c94f0806", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "43c58869-e208-4961-8de5-5d91285c57d8", false, "Admin" });
        }
    }
}
