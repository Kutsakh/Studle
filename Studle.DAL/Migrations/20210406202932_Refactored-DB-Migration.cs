using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studle.DAL.Migrations
{
    public partial class RefactoredDBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Subjects_Subject_id",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Users_Student_id",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_Teacher_id",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Teacher_id",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Cathedra",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Middle_name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Open_access",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Teacher_id",
                table: "Subjects",
                newName: "DurationSemesters");

            migrationBuilder.RenameColumn(
                name: "Subject_id",
                table: "Marks",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "Student_id",
                table: "Marks",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_Subject_id",
                table: "Marks",
                newName: "IX_Marks_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_Student_id",
                table: "Marks",
                newName: "IX_Marks_TeacherId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Marks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Marks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    GroupNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    AdmissionYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupHasSubjects",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupHasSubjects", x => new { x.GroupsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_GroupHasSubjects_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupHasSubjects_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupHasSubjects_SubjectsId",
                table: "GroupHasSubjects",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SubjectId",
                table: "Topics",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Teachers_TeacherId",
                table: "Marks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Topics_TopicId",
                table: "Marks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Teachers_TeacherId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Topics_TopicId",
                table: "Marks");

            migrationBuilder.DropTable(
                name: "GroupHasSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Marks_StudentId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "First_name");

            migrationBuilder.RenameColumn(
                name: "DurationSemesters",
                table: "Subjects",
                newName: "Teacher_id");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Marks",
                newName: "Subject_id");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Marks",
                newName: "Student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_TopicId",
                table: "Marks",
                newName: "IX_Marks_Subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_TeacherId",
                table: "Marks",
                newName: "IX_Marks_Student_id");

            migrationBuilder.AddColumn<string>(
                name: "Cathedra",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Middle_name",
                table: "Users",
                type: "TEXT",
                maxLength: 225,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Open_access",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Hours",
                table: "Subjects",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Subjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Point",
                table: "Marks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Marks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Teacher_id",
                table: "Subjects",
                column: "Teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Subjects_Subject_id",
                table: "Marks",
                column: "Subject_id",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Users_Student_id",
                table: "Marks",
                column: "Student_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_Teacher_id",
                table: "Subjects",
                column: "Teacher_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
