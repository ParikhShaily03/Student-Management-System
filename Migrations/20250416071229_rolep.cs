using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class rolep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e21d504-37e4-4079-838d-7888fc5b0a88");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1134f59-58fe-4864-92b8-f08483e90348");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60406725-663e-4549-a218-e562a165449f", 0, "ef2f2b90-a6b0-41a0-bf42-be6034148408", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "fd09bc40-1133-4e17-b24e-58c80bb742f4", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f792549d-6332-4a6c-9a87-02cab66ea029", 0, "15c9d0a6-4ec9-44f5-9727-4a118614b18b", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "a8d6305f-89c4-4334-9428-5effc902c288", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60406725-663e-4549-a218-e562a165449f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f792549d-6332-4a6c-9a87-02cab66ea029");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e21d504-37e4-4079-838d-7888fc5b0a88", 0, "6b0b96a2-dcb4-463a-812f-ef5c9b9b8d08", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "f55eefa0-b707-47e9-b537-b8b3bf202ebd", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1134f59-58fe-4864-92b8-f08483e90348", 0, "20a5ff56-0c34-4cc3-bc7d-29cfb6e7375b", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "81eb5a7c-3382-49c2-80ed-0da6ad9bdf9d", false, "Admin" });
        }
    }
}
