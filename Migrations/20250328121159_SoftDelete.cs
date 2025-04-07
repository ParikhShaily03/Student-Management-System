using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3afe9977-1938-4fb3-820f-27f36203ebcb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6931be4c-a7c6-4ad3-b7a7-ab359bc648ae");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66ac5579-77a9-4617-a446-ebcb25db86f7", 0, "752ec899-2910-4d6d-9b63-0b89aed39f3c", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "7e3a3b6c-fb2f-49aa-ad23-b16a07336e61", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8308eee0-9ab6-4dea-9c67-dca8657a19bc", 0, "17a60d78-2f61-4507-81b1-45a386d9968d", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "bbd32bce-4231-4b3a-bee4-4764579db627", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66ac5579-77a9-4617-a446-ebcb25db86f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8308eee0-9ab6-4dea-9c67-dca8657a19bc");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3afe9977-1938-4fb3-820f-27f36203ebcb", 0, "0941a1a8-f053-489b-9d66-4a6adb757254", "CE", "admin@example.com", false, false, null, "MyAdmin1", null, null, null, null, false, "35c696b9-2746-4ab3-b7e3-80105f2fb06f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6931be4c-a7c6-4ad3-b7a7-ab359bc648ae", 0, "9cdf14ed-a422-4861-84dd-94c75180e44b", "CE", "user@example.com", false, false, null, "MyUser1", null, null, null, null, false, "5ab5497c-7290-4322-bd81-eb998eb89882", false, "User" });
        }
    }
}
