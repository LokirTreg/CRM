using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.WEB.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Course_Course_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Group_Group_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Teacher_Teacher_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Сlassroom_Сlassroom_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Сlassroom_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Course_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Group_Id",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_Teacher_Id",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Сlassroom_Id",
                table: "Event",
                newName: "СlassroomId");

            migrationBuilder.RenameColumn(
                name: "Teacher_Id",
                table: "Event",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "Group_Id",
                table: "Event",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "Course_Id",
                table: "Event",
                newName: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_СlassroomId",
                table: "Event",
                column: "СlassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CourseId",
                table: "Event",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_GroupId",
                table: "Event",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TeacherId",
                table: "Event",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Course_CourseId",
                table: "Event",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Group_GroupId",
                table: "Event",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Teacher_TeacherId",
                table: "Event",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Сlassroom_СlassroomId",
                table: "Event",
                column: "СlassroomId",
                principalTable: "Сlassroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Course_CourseId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Group_GroupId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Teacher_TeacherId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Сlassroom_СlassroomId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_СlassroomId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_CourseId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_GroupId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_TeacherId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "СlassroomId",
                table: "Event",
                newName: "Сlassroom_Id");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Event",
                newName: "Teacher_Id");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Event",
                newName: "Group_Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Event",
                newName: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Сlassroom_Id",
                table: "Event",
                column: "Сlassroom_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_Course_Id",
                table: "Event",
                column: "Course_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_Group_Id",
                table: "Event",
                column: "Group_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_Teacher_Id",
                table: "Event",
                column: "Teacher_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Course_Course_Id",
                table: "Event",
                column: "Course_Id",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Group_Group_Id",
                table: "Event",
                column: "Group_Id",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Teacher_Teacher_Id",
                table: "Event",
                column: "Teacher_Id",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Сlassroom_Сlassroom_Id",
                table: "Event",
                column: "Сlassroom_Id",
                principalTable: "Сlassroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
