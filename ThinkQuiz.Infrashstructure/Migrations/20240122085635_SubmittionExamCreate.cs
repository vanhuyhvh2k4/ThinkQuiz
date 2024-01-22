using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThinkQuiz.Infrashstructure.Migrations
{
    /// <inheritdoc />
    public partial class SubmittionExamCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmittionExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ExamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Point = table.Column<double>(type: "double", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittionExams", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubmittionExamAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QuestionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChoiceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SubmittionExamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittionExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittionExamAnswers_SubmittionExams_SubmittionExamId",
                        column: x => x.SubmittionExamId,
                        principalTable: "SubmittionExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittionExamAnswers_SubmittionExamId",
                table: "SubmittionExamAnswers",
                column: "SubmittionExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittionExamAnswers");

            migrationBuilder.DropTable(
                name: "SubmittionExams");
        }
    }
}
