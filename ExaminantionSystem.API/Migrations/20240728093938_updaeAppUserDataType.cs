using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminantionSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class updaeAppUserDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_AppUserId1",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_AppUserId1",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_AppUserId",
                table: "StudentCourses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_AppUserId",
                table: "StudentCourses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_AppUserId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_AppUserId",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_AppUserId1",
                table: "StudentCourses",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_AppUserId1",
                table: "StudentCourses",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
