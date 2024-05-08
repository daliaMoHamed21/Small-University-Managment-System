using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Day3.Migrations
{
    /// <inheritdoc />
    public partial class Cs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "departments");
        }
    }
}
