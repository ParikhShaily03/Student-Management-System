using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class New2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9f405a8-9a95-4d50-97c5-c90e7b7864e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f619e087-03e1-4b9f-90aa-3ec3bd459d59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15a375e4-fb81-4e8f-83d1-5c3e403fb870", 0, "4e6b6e52-58ab-43a2-ab23-6dc9223f9f92", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5e61182a-6777-45e0-b1f5-b5880becaf8e", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c0f5e10-69fd-4605-aa34-6a7d617bb79d", 0, "f4061562-e8fe-4131-a71f-37241574fcf2", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "9a5e7c44-92b3-4497-b5b0-7a7fcff38f86", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a375e4-fb81-4e8f-83d1-5c3e403fb870");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c0f5e10-69fd-4605-aa34-6a7d617bb79d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b9f405a8-9a95-4d50-97c5-c90e7b7864e7", 0, "cf433feb-ff32-4ec3-a2ef-7c21bd19cc93", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "f89a40ef-0968-4cf8-a38f-220f83463283", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f619e087-03e1-4b9f-90aa-3ec3bd459d59", 0, "2cab934a-8920-4769-867b-a927785b2c3f", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "f1ccbcd9-b947-48c8-bccc-24eab7ae9d9f", false, "User" });
        }
    }
}
