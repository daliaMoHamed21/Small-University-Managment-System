using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Day3.Migrations
{
    /// <inheritdoc />
    public partial class lina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "departments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
