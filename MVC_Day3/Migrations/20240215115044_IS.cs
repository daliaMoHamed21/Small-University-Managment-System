using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Day3.Migrations
{
    /// <inheritdoc />
    public partial class IS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DEPT_No",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "DEPT_No",
                table: "students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_students_DEPT_No",
                table: "students",
                newName: "IX_students_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DEPT_Id",
                table: "departments",
                newName: "DeptId");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DepartmentId",
                table: "students",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DepartmentId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "students",
                newName: "DEPT_No");

            migrationBuilder.RenameIndex(
                name: "IX_students_DepartmentId",
                table: "students",
                newName: "IX_students_DEPT_No");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "departments",
                newName: "DEPT_Id");

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DEPT_No",
                table: "students",
                column: "DEPT_No",
                principalTable: "departments",
                principalColumn: "DEPT_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
