using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a72cae5-caea-4962-b295-f0066641ba0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96605227-0aa6-4dfe-9b70-546b305793bf");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Menus");

            migrationBuilder.CreateTable(
                name: "menuRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menuRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menuRoles_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a432750-c441-4354-973a-5e35f0b0c9c6", 0, "2ad882e8-65e2-4259-9fb4-a64177c77dc7", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "55f9a917-4979-4dbd-9077-3dc3ef94e84f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86c80133-c7f4-40fc-8fa3-86dc09f50e4c", 0, "10d1c025-cc5c-44df-a73b-f30b0d3910ef", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "1d1eba84-c814-4c05-87c2-870c417bcd15", false, "User" });

            migrationBuilder.CreateIndex(
                name: "IX_menuRoles_MenuId",
                table: "menuRoles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_menuRoles_RoleId",
                table: "menuRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menuRoles");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a432750-c441-4354-973a-5e35f0b0c9c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86c80133-c7f4-40fc-8fa3-86dc09f50e4c");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a72cae5-caea-4962-b295-f0066641ba0a", 0, "8da2f703-1b49-484e-845f-84c509915364", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "675cbf19-bdec-4fb8-8b08-4f6673c08bd0", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "96605227-0aa6-4dfe-9b70-546b305793bf", 0, "50cfa088-f4f5-45e9-b016-5eddd222b9dd", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "61d6d890-2119-40e8-a3a2-ef4de85421a2", false, "Admin" });
        }
    }
}
