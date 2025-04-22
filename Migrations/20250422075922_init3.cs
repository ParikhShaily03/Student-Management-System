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
                keyValue: "3cc0a92c-f772-4522-9baf-c493d4016c36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0010539-e4d1-415e-b922-5841efa407b4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ba4043f-ca99-4855-989d-77314a8dec47", 0, "a5c9acff-db33-4b47-870a-b699e2c5792f", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "0c07e86e-7c24-48bc-a41f-ed7711438beb", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4472a6e-670c-4b4a-a9e4-216d2bd8d648", 0, "23e94d0a-9be6-4cdb-be0c-28b71bd21bd8", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "35993780-d0da-4d32-8b46-421f3745718e", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ba4043f-ca99-4855-989d-77314a8dec47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4472a6e-670c-4b4a-a9e4-216d2bd8d648");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cc0a92c-f772-4522-9baf-c493d4016c36", 0, "ec339b12-b877-4561-888d-157c8c6a568e", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "e3c1acb2-f136-4016-8c4b-a26df23c4a70", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e0010539-e4d1-415e-b922-5841efa407b4", 0, "be03b7dc-35ae-4852-a37a-64c161c75ab5", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c6622166-4d1d-4f9a-bf97-d2e11470501f", false, "Admin" });
        }
    }
}
