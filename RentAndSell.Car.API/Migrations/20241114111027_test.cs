using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAndSell.Car.API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "93f5718f-0049-4780-8c02-70b6b495bd55", "6feb259d-80aa-4efe-a830-32217e2d99b2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93f5718f-0049-4780-8c02-70b6b495bd55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6feb259d-80aa-4efe-a830-32217e2d99b2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1eed64f-9898-4a4c-874e-f489b8dcc4b3", "b10a6798-697f-4e24-b6cc-a41ec51c5816", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6e2b8f0-5afc-4b45-9c3d-6d9d6cc2c881", 0, "e7f39af9-26f6-445d-8072-77509e5315e0", "admin@mail.com", true, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEKicOQcE484SgJ9TN0Yhcz058MVIgoFLwvuttPVyA9VEMHh1+dJRFDThA8Qe6Iv/ng==", null, false, "a65ebe46-f585-485c-a7ef-59ebe14bc335", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f1eed64f-9898-4a4c-874e-f489b8dcc4b3", "b6e2b8f0-5afc-4b45-9c3d-6d9d6cc2c881" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1eed64f-9898-4a4c-874e-f489b8dcc4b3", "b6e2b8f0-5afc-4b45-9c3d-6d9d6cc2c881" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1eed64f-9898-4a4c-874e-f489b8dcc4b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6e2b8f0-5afc-4b45-9c3d-6d9d6cc2c881");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93f5718f-0049-4780-8c02-70b6b495bd55", "fd2d77ee-879c-4324-a808-bdc9361e3729", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6feb259d-80aa-4efe-a830-32217e2d99b2", 0, "3072dff9-b91f-402c-8537-f05fe371fd7f", "admin@mail.com", true, "Admin", "User", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEGcZycw4DVFN5bbMyn7c86/Vs31TfmGBxB8UhZOr5usDHbU36nGLJWcCHlz5fQckLA==", null, false, "9e783479-3356-4ca9-b53b-7db910868966", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "93f5718f-0049-4780-8c02-70b6b495bd55", "6feb259d-80aa-4efe-a830-32217e2d99b2" });
        }
    }
}
