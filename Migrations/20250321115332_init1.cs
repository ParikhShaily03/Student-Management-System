
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9581e643-e23e-47ba-bcfd-d1323a25c41d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d406910d-7dc8-471f-999e-cc6e888b62ae");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "79a2aca1-8136-4501-a8a4-dc4b797901db", 0, "45ead01b-95d2-4147-88a6-bcd70364958a", "CE", "admin@example.com", false, false, null, "MyAdmin1", null, null, null, null, false, "305643fb-fba2-4787-9b8f-60ef199d065f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fafc2cb8-845e-4308-ac8c-7c954b1ab69f", 0, "122101ed-5cb3-4aad-873d-82d780f1c0e9", "CE", "user@example.com", false, false, null, "MyUser1", null, null, null, null, false, "5289af13-59fa-4fbf-8d70-538b04bce1f1", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79a2aca1-8136-4501-a8a4-dc4b797901db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fafc2cb8-845e-4308-ac8c-7c954b1ab69f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9581e643-e23e-47ba-bcfd-d1323a25c41d", 0, "e197c864-84ce-4004-b27c-17bcd693fb26", "CE", "user@example.com", false, false, null, "MyUser1", null, null, null, null, false, "1e79fd31-5dc4-4350-ad5e-b122f2d4ae1c", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d406910d-7dc8-471f-999e-cc6e888b62ae", 0, "2cbfb8f9-070a-498a-ba42-ca7ce312a9fd", "CE", "admin@example.com", false, false, null, "MyAdmin1", null, null, null, null, false, "c2bc55cc-9949-4b95-9dd0-18cf1fdf6c0b", false, "Admin" });
        }
    }
}
