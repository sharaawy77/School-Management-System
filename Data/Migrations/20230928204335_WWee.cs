using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class WWee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAttendances_Students_StudentId",
                table: "StudentsAttendances");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAttendances_StudentId",
                table: "StudentsAttendances");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentsAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamQuestionId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsAttendances_StudentId",
                table: "StudentsAttendances",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ExamId_ExamQuestionId",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId" },
                principalTable: "ExamQuestion",
                principalColumns: new[] { "ExamId", "QuestionId" });

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
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsAttendances_Students_StudentId",
                table: "StudentsAttendances");

            migrationBuilder.DropIndex(
                name: "IX_StudentsAttendances_StudentId",
                table: "StudentsAttendances");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId_ExamQuestionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentsAttendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsAttendances_StudentId",
                table: "StudentsAttendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsAttendances_Students_StudentId",
                table: "StudentsAttendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }
    }
}
