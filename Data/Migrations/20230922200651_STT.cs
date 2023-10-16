using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class STT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAttendance_Students_StudentId",
                table: "StudentsAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsAttendance",
                table: "StudentsAttendance");

            migrationBuilder.RenameTable(
                name: "StudentsAttendance",
                newName: "StudentsAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsAttendance_StudentId",
                table: "StudentsAttendances",
                newName: "IX_StudentsAttendances_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsAttendances",
                table: "StudentsAttendances",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAttendances_Students_StudentId",
                table: "StudentsAttendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAttendances_Students_StudentId",
                table: "StudentsAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsAttendances",
                table: "StudentsAttendances");

            migrationBuilder.RenameTable(
                name: "StudentsAttendances",
                newName: "StudentsAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsAttendances_StudentId",
                table: "StudentsAttendance",
                newName: "IX_StudentsAttendance_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsAttendance",
                table: "StudentsAttendance",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAttendance_Students_StudentId",
                table: "StudentsAttendance",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
