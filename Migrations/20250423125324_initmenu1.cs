using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initmenu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26872d11-61d0-4201-aa9b-db28f8e52806");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55d59edc-49ad-4400-9b5d-ee81388b28f5");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Menus");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fbded7b-a2e7-42d3-900e-db554b0c653b", 0, "d93a9575-1e08-4ada-a816-8f3a30b01c06", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "76a0648a-558f-430a-8ba2-89c73e936505", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0ecff55-b639-4de8-b6ab-c07bf0d755a5", 0, "479d064d-a42d-4bb7-8370-fac694118e5b", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "db235380-0702-493d-ac33-1cc94512a555", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fbded7b-a2e7-42d3-900e-db554b0c653b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0ecff55-b639-4de8-b6ab-c07bf0d755a5");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "26872d11-61d0-4201-aa9b-db28f8e52806", 0, "55e0a4ba-5089-4e62-926b-45103deae493", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "2e007c24-8b5d-4970-8303-b5cf894e5ae2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55d59edc-49ad-4400-9b5d-ee81388b28f5", 0, "f1054f9f-c645-4fbc-b4f3-26d8d855fe92", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "b24cdc79-ff1e-4013-94f3-c33e182fcd3d", false, "User" });
        }
    }
}
