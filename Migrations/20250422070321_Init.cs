using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66af7ae3-11db-4622-91bd-bb2e10634100");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc743e36-b58b-44b5-b165-ad864839ceae");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "66af7ae3-11db-4622-91bd-bb2e10634100", 0, "2ad9c0fa-0df3-4e68-8cb5-45bb20035f25", "CE", "user@example.com", false, false, false, null, "MyUser1", null, null, null, null, false, "9d6d85b3-6a9b-406c-9c52-53cd0c583c41", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc743e36-b58b-44b5-b165-ad864839ceae", 0, "4da314bd-4a2e-49ab-b39b-286d9e6588d1", "CE", "admin@example.com", false, false, false, null, "MyAdmin1", null, null, null, null, false, "c7cc351d-bcf6-4dfe-a494-bc099f1739e6", false, "Admin" });
        }
    }
}
