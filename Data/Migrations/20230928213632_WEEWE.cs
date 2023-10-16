using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class WEEWE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId_ExamQuestionId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId",
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

            migrationBuilder.AddColumn<int>(
                name: "ExamQuestionId1",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId1",
                table: "Students",
                columns: new[] { "ExamId", "ExamQuestionId1" },
                principalTable: "ExamQuestion",
                principalColumns: new[] { "ExamId", "QuestionId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ExamQuestion_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId_ExamQuestionId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId1",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ExamQuestionId",
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
        }
    }
}
