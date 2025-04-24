using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b3a98af-282c-4f0e-be9c-a743f84e1115");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc567ea-1801-4a43-97ba-970e09923dee");

            migrationBuilder.AddColumn<string>(
                name: "CssClass",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExternal",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubMenu",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5493509f-b7ad-4be4-986c-2daafae1f40c", 0, "fd7ade92-a8e7-470d-acd7-743941a67af0", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "3a640af8-3ecb-45e9-b2ce-6c5b19464257", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c06bfd1d-e6cb-4379-a75f-b88cf996a2d7", 0, "af6b55a7-e5fb-4319-a395-d203bc90d76c", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "632bd507-4f62-4913-9af5-9da828edac4e", false, "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus",
                column: "ParentId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ParentId",
                table: "Menus");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5493509f-b7ad-4be4-986c-2daafae1f40c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c06bfd1d-e6cb-4379-a75f-b88cf996a2d7");

            migrationBuilder.DropColumn(
                name: "CssClass",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsExternal",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsSubMenu",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Menus");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2b3a98af-282c-4f0e-be9c-a743f84e1115", 0, "e8bde6ab-b199-4ae8-9583-527356d6c0db", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "d43f2ddf-b563-4fd8-849b-7994f326c210", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "afc567ea-1801-4a43-97ba-970e09923dee", 0, "aae41441-695c-43b4-9d6e-fb644d9f9d4b", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c4079a37-778a-4110-800e-f5e2db489b1e", false, "Admin" });
        }
    }
}
