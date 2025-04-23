using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initmenu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3213c37e-b369-4501-bf19-7428106e2977", 0, "5ed3960c-c588-4f30-baf6-83b9e4374d6b", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "07f3ae1a-a46e-48d9-aabe-9b8c9667034c", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b608502c-18a2-4142-ac8d-dac04e609f08", 0, "fc032d97-19f9-456a-b6b5-5890d2fd1708", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "2533e12d-1bdf-467a-9e02-6bdc1d4b6137", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3213c37e-b369-4501-bf19-7428106e2977");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b608502c-18a2-4142-ac8d-dac04e609f08");

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
    }
}
