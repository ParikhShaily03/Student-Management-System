using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class AddMenuRolePermissionremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "154eca5f-d014-4529-8cea-120c255abfd5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acf28d4d-7e79-4476-925c-45930216c616");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "menuRoles");

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "MenuRolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "002b938b-a848-4d18-ac36-4c5cfdd3132e", 0, "92202bdf-dc16-4b1e-89db-78323b0a0998", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "229af894-fc70-4f22-831f-f451b5082eae", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a5a2e1e-7951-4301-acb0-3bcc804494ba", 0, "85792399-bef5-49c3-b71c-4ed7d974a75f", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "6f52b57d-ef14-4fed-bc44-9ddeec7bbe51", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "002b938b-a848-4d18-ac36-4c5cfdd3132e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a5a2e1e-7951-4301-acb0-3bcc804494ba");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "MenuRolePermissions");

            migrationBuilder.AddColumn<int>(
                name: "Permissions",
                table: "menuRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "154eca5f-d014-4529-8cea-120c255abfd5", 0, "611eb998-ea95-4e53-83a1-5e8594047a4e", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, null, null, false, "42ff9675-930e-49d6-b483-adb6da8b8544", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpExpiryTime", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "acf28d4d-7e79-4476-925c-45930216c616", 0, "3321e2f6-041d-45e7-b538-15a19fc7a960", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, null, null, false, "29e907ce-6934-4a30-9227-abacf6568391", false, "User" });
        }
    }
}
