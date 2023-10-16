using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class WWWWEQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion");

            migrationBuilder.RenameTable(
                name: "ExamQuestion",
                newName: "ExamQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                columns: new[] { "ExamId", "QuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" },
                principalTable: "ExamQuestions",
                principalColumns: new[] { "ExamId", "QuestionId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestions_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "ExamQuestions",
                newName: "ExamQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion",
                columns: new[] { "ExamId", "QuestionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" },
                principalTable: "ExamQuestion",
                principalColumns: new[] { "ExamId", "QuestionId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
