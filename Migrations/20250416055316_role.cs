using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a375e4-fb81-4e8f-83d1-5c3e403fb870");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c0f5e10-69fd-4605-aa34-6a7d617bb79d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e21d504-37e4-4079-838d-7888fc5b0a88", 0, "6b0b96a2-dcb4-463a-812f-ef5c9b9b8d08", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "f55eefa0-b707-47e9-b537-b8b3bf202ebd", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1134f59-58fe-4864-92b8-f08483e90348", 0, "20a5ff56-0c34-4cc3-bc7d-29cfb6e7375b", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "81eb5a7c-3382-49c2-80ed-0da6ad9bdf9d", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "15a375e4-fb81-4e8f-83d1-5c3e403fb870", 0, "4e6b6e52-58ab-43a2-ab23-6dc9223f9f92", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "5e61182a-6777-45e0-b1f5-b5880becaf8e", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c0f5e10-69fd-4605-aa34-6a7d617bb79d", 0, "f4061562-e8fe-4131-a71f-37241574fcf2", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "9a5e7c44-92b3-4497-b5b0-7a7fcff38f86", false, "Admin" });
        }
    }
}
