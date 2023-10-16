using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewQQQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherAttendances_AttendanceId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AttendanceId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeacherAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_TeacherId",
                table: "TeacherAttendances",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherAttendances_Teachers_TeacherId",
                table: "TeacherAttendances",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherAttendances_Teachers_TeacherId",
                table: "TeacherAttendances");

            migrationBuilder.DropIndex(
                name: "IX_TeacherAttendances_TeacherId",
                table: "TeacherAttendances");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherAttendances");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AttendanceId",
                table: "Teachers",
                column: "AttendanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherAttendances_AttendanceId",
                table: "Teachers",
                column: "AttendanceId",
                principalTable: "TeacherAttendances",
                principalColumn: "AttendanceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
