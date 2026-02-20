using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveMangementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class usingCustomizeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff962c0c-e707-40bc-bc98-fe0e25eed36b",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a68b35ed-4919-4371-8148-afdc5b4fcb30", new DateOnly(1990, 12, 6), "Default", "Admin", "AQAAAAIAAYagAAAAEN0qOL96JhbeKTrhhOX4RKbInsh0W2PcefGDVmmKJWtVU8YtMajmvio+0sMM5xQUMA==", "ee324cbe-b663-4d81-ae5f-7801f71b3bbe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff962c0c-e707-40bc-bc98-fe0e25eed36b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99b6e467-178e-4d7d-be48-b0b95688797c", "AQAAAAIAAYagAAAAELTcvFIHib0j9Y3+JCnVa/TFZBL00lHHHShIQn54H2NMlFgyzIsqQxA/t9roIfXf2g==", "a20d41f7-2468-4056-ad34-cfd0f6babe30" });
        }
    }
}
