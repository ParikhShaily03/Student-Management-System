using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Catremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "256583be-111b-443b-97b5-c8aa905002bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cae5555-b7c2-486f-8453-394e30102d1a");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Permissions");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66af7ae3-11db-4622-91bd-bb2e10634100", 0, "2ad9c0fa-0df3-4e68-8cb5-45bb20035f25", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "9d6d85b3-6a9b-406c-9c52-53cd0c583c41", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc743e36-b58b-44b5-b165-ad864839ceae", 0, "4da314bd-4a2e-49ab-b39b-286d9e6588d1", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c7cc351d-bcf6-4dfe-a494-bc099f1739e6", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66af7ae3-11db-4622-91bd-bb2e10634100");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc743e36-b58b-44b5-b165-ad864839ceae");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "256583be-111b-443b-97b5-c8aa905002bf", 0, "4d30c5e6-5551-4157-b19a-a93f4f3c8536", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "3940b0d8-d20a-4059-b72b-147016beb527", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9cae5555-b7c2-486f-8453-394e30102d1a", 0, "8967a8b3-52ce-4d98-9d1f-6e70d4f56fec", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "88a67037-d1d5-45d1-a3f4-d11083d703a9", false, "Admin" });
        }
    }
}
