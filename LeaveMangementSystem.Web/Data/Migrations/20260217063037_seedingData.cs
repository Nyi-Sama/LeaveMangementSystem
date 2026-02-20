using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveMangementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23bd33d8-ae5b-43fe-8ef5-6965471ec9ed", null, "Administrator", "ADMINISTRATOR" },
                    { "47cc7249-bac1-4448-81ca-872fcc6d92a4", null, "Supervisor", "SUPERVISOR" },
                    { "96b39053-9d15-4f04-be97-5ba91312b436", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff962c0c-e707-40bc-bc98-fe0e25eed36b", 0, "99b6e467-178e-4d7d-be48-b0b95688797c", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELTcvFIHib0j9Y3+JCnVa/TFZBL00lHHHShIQn54H2NMlFgyzIsqQxA/t9roIfXf2g==", null, false, "a20d41f7-2468-4056-ad34-cfd0f6babe30", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23bd33d8-ae5b-43fe-8ef5-6965471ec9ed", "ff962c0c-e707-40bc-bc98-fe0e25eed36b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47cc7249-bac1-4448-81ca-872fcc6d92a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b39053-9d15-4f04-be97-5ba91312b436");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23bd33d8-ae5b-43fe-8ef5-6965471ec9ed", "ff962c0c-e707-40bc-bc98-fe0e25eed36b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23bd33d8-ae5b-43fe-8ef5-6965471ec9ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff962c0c-e707-40bc-bc98-fe0e25eed36b");
        }
    }
}
