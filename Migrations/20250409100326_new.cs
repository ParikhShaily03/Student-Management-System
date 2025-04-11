using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "07d7f6f9-02d2-48b0-845c-694288f187ea", 0, "2c4ee0a4-addf-49e2-b21d-41e1f510ab32", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "a320c5fe-9c90-4410-b87e-391bd29c2edf", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2194b7f3-d1e4-4690-b362-7ec7ef3acd1b", 0, "d2494a92-6524-4c86-b199-6604656e5300", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "54795594-1a88-41e2-ad0f-1261b3200c28", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07d7f6f9-02d2-48b0-845c-694288f187ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2194b7f3-d1e4-4690-b362-7ec7ef3acd1b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "37a300ce-735d-4265-8463-54accb1163b2", 0, "f00eb6ea-1cd3-4c04-bd3e-240926453834", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "7c807291-aaba-48af-ad98-bb4e1dab0a94", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de9fe56d-7661-4aea-b8d7-48183023928d", 0, "2fecf2f6-bb6d-4067-befe-03f4f7ae9991", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "4d56195f-2675-43bb-9e5b-9de925f251d1", false, "User" });
        }
    }
}
