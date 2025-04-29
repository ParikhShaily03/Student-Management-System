using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class initrole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52323e02-06ed-47d2-b4b0-05db15a1ed57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ccda09e-96db-4d46-9ed7-305ae9ecbf95");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a72cae5-caea-4962-b295-f0066641ba0a", 0, "8da2f703-1b49-484e-845f-84c509915364", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "675cbf19-bdec-4fb8-8b08-4f6673c08bd0", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "96605227-0aa6-4dfe-9b70-546b305793bf", 0, "50cfa088-f4f5-45e9-b016-5eddd222b9dd", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "61d6d890-2119-40e8-a3a2-ef4de85421a2", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a72cae5-caea-4962-b295-f0066641ba0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96605227-0aa6-4dfe-9b70-546b305793bf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "52323e02-06ed-47d2-b4b0-05db15a1ed57", 0, "81ec1be4-232e-4995-83e6-2cad35bdb7f2", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "9fabf50a-e4c5-4b04-8b7d-a73d0c2e8d77", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ccda09e-96db-4d46-9ed7-305ae9ecbf95", 0, "83c5b61a-1699-4514-824a-e3bb17372b2f", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "ca732861-b88c-4ffb-9db4-d21c09be07a8", false, "Admin" });
        }
    }
}
