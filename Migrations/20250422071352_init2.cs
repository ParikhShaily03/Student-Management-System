using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a28f337-8b90-46df-bfd5-ef855c8b98eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b123ea94-36cb-4c40-bd96-9bc78b22bb72");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "11308420-966a-4141-bed0-4784bd4e9675");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "2ad2dae6-ff7d-43d7-b44a-97f842c6fb9f");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "78bcff4f-877c-466e-9aa5-f695341e5c8d");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "881fa119-9e8b-4e5a-8ea3-c8a61acca718");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "8bca3af9-44ee-4fca-8082-022d48b10a59");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "9253d0bf-7b0e-490e-8637-08bca8dba277");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "d685db20-6e5e-403f-a6c5-073591080237");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "fc2029c3-69b5-49ce-8619-c1c0f9a15abf");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cc0a92c-f772-4522-9baf-c493d4016c36", 0, "ec339b12-b877-4561-888d-157c8c6a568e", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "e3c1acb2-f136-4016-8c4b-a26df23c4a70", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e0010539-e4d1-415e-b922-5841efa407b4", 0, "be03b7dc-35ae-4852-a37a-64c161c75ab5", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c6622166-4d1d-4f9a-bf97-d2e11470501f", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cc0a92c-f772-4522-9baf-c493d4016c36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0010539-e4d1-415e-b922-5841efa407b4");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Permissions");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a28f337-8b90-46df-bfd5-ef855c8b98eb", 0, "fcb58f0f-727f-4908-a9c2-056c2c4baef2", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "ab46576d-6044-4901-97cc-b9bea4a43a64", false, "Admin" },
                    { "b123ea94-36cb-4c40-bd96-9bc78b22bb72", 0, "efdfb31a-d4ff-406b-b260-66c9527ef3d9", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "988fc8ae-5acc-420d-88c0-3bef5394d1be", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "11308420-966a-4141-bed0-4784bd4e9675", "Create" },
                    { "2ad2dae6-ff7d-43d7-b44a-97f842c6fb9f", "View" },
                    { "78bcff4f-877c-466e-9aa5-f695341e5c8d", "Write" },
                    { "881fa119-9e8b-4e5a-8ea3-c8a61acca718", "Export" },
                    { "8bca3af9-44ee-4fca-8082-022d48b10a59", "Read" },
                    { "9253d0bf-7b0e-490e-8637-08bca8dba277", "Delete" },
                    { "d685db20-6e5e-403f-a6c5-073591080237", "Approve" },
                    { "fc2029c3-69b5-49ce-8619-c1c0f9a15abf", "Edit" }
                });
        }
    }
}
