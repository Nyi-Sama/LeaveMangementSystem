using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveMangementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingLeaveTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "leaveTypes",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "leaveTypes",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");
        }
    }
}
