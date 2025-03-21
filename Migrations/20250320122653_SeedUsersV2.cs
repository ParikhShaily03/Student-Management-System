using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class SeedUsersV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9581e643-e23e-47ba-bcfd-d1323a25c41d", 0, "e197c864-84ce-4004-b27c-17bcd693fb26", "CE", "user@example.com", false, false, null, "MyUser1", null, null, null, null, false, "1e79fd31-5dc4-4350-ad5e-b122f2d4ae1c", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d406910d-7dc8-471f-999e-cc6e888b62ae", 0, "2cbfb8f9-070a-498a-ba42-ca7ce312a9fd", "CE", "admin@example.com", false, false, null, "MyAdmin1", null, null, null, null, false, "c2bc55cc-9949-4b95-9dd0-18cf1fdf6c0b", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1", 0, "7c1bf3f3-4e99-41af-950d-607501b1ff7a", "CE", "admin@example.com", false, false, null, "MyAdmin", null, null, null, null, false, "2a7253df-e8b9-47a9-9e60-2e7d3ed278f4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "15516f0c-5b6a-4ccb-a96b-0668e9714afc", "CE", "user@example.com", false, false, null, "MyUser", null, null, null, null, false, "a51baf98-475a-4297-a6ea-befca9675c54", false, "User" });
        }
    }
}
