using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class EQQQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId1",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId1",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" },
                principalTable: "ExamQuestions",
                principalColumns: new[] { "ExamId", "QuestionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId1",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId1",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" },
                principalTable: "ExamQuestions",
                principalColumns: new[] { "ExamId", "QuestionId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
