using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difficulty_Learning.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_Courses",
                columns: table => new
                {
                    CategoryCourse_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCourse_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Courses", x => x.CategoryCourse_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Types",
                columns: table => new
                {
                    UserType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Types", x => x.UserType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Watched_Historys",
                columns: table => new
                {
                    WatchedHistory_ID = table.Column<int>(type: "int", nullable: false),
                    WatchedHistory_UserID = table.Column<int>(type: "int", nullable: false),
                    WatchedHistory_CourseID = table.Column<int>(type: "int", nullable: false),
                    WatchedHistory_Timeing = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Users_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Users_TypeID = table.Column<int>(type: "int", nullable: false),
                    Users_UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User_Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    User_FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    User_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Users_Active = table.Column<bool>(type: "bit", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Users_ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_UserID = table.Column<int>(type: "int", nullable: false),
                    Course_CategoryID = table.Column<int>(type: "int", nullable: false),
                    Course_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Course_Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_ID);
                    table.ForeignKey(
                        name: "FK_Courses_Users_Course_UserID",
                        column: x => x.Course_UserID,
                        principalTable: "Users",
                        principalColumn: "Users_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Course_UserID",
                table: "Courses",
                column: "Course_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Course_ID",
                table: "Users",
                column: "Course_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_Course_ID",
                table: "Users",
                column: "Course_ID",
                principalTable: "Courses",
                principalColumn: "Course_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_Course_UserID",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Category_Courses");

            migrationBuilder.DropTable(
                name: "User_Types");

            migrationBuilder.DropTable(
                name: "Watched_Historys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
