using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class change_offId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offices_InstructorId",
                table: "Offices");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Offices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_InstructorId",
                table: "Offices",
                column: "InstructorId",
                unique: true,
                filter: "[InstructorId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offices_InstructorId",
                table: "Offices");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Offices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_InstructorId",
                table: "Offices",
                column: "InstructorId",
                unique: true);
        }
    }
}
