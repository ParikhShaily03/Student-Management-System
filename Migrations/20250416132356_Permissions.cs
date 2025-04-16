using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71f15c23-5fee-47d5-87b7-3a103eabe51c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bef0d5f7-5513-43f5-90c3-4cb01f069caf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "256583be-111b-443b-97b5-c8aa905002bf", 0, "4d30c5e6-5551-4157-b19a-a93f4f3c8536", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "3940b0d8-d20a-4059-b72b-147016beb527", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9cae5555-b7c2-486f-8453-394e30102d1a", 0, "8967a8b3-52ce-4d98-9d1f-6e70d4f56fec", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "88a67037-d1d5-45d1-a3f4-d11083d703a9", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "256583be-111b-443b-97b5-c8aa905002bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cae5555-b7c2-486f-8453-394e30102d1a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71f15c23-5fee-47d5-87b7-3a103eabe51c", 0, "c569e846-ba58-4cab-9501-73d0d93a7644", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "dc3d94c8-22ce-47af-b284-1b99a51feaa6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bef0d5f7-5513-43f5-90c3-4cb01f069caf", 0, "a751db76-1803-4e15-8d6b-cd2b7670197c", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "298d3b86-e8d0-4b06-901d-7ff868d41718", false, "User" });
        }
    }
}
