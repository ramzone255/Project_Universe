using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Universe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Task_Project_id_project",
                table: "Project_Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Task_Task_id_task",
                table: "Project_Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Staff_Staff_id_staff",
                table: "Task_Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Staff_Task_id_task",
                table: "Task_Staff");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Task_Project_id_project",
                table: "Project_Task",
                column: "id_project",
                principalTable: "Project",
                principalColumn: "id_project",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Task_Task_id_task",
                table: "Project_Task",
                column: "id_task",
                principalTable: "Task",
                principalColumn: "id_task",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Staff_Staff_id_staff",
                table: "Task_Staff",
                column: "id_staff",
                principalTable: "Staff",
                principalColumn: "id_staff",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Staff_Task_id_task",
                table: "Task_Staff",
                column: "id_task",
                principalTable: "Task",
                principalColumn: "id_task",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Task_Project_id_project",
                table: "Project_Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Task_Task_id_task",
                table: "Project_Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Staff_Staff_id_staff",
                table: "Task_Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Staff_Task_id_task",
                table: "Task_Staff");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Task_Project_id_project",
                table: "Project_Task",
                column: "id_project",
                principalTable: "Project",
                principalColumn: "id_project");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Task_Task_id_task",
                table: "Project_Task",
                column: "id_task",
                principalTable: "Task",
                principalColumn: "id_task");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Staff_Staff_id_staff",
                table: "Task_Staff",
                column: "id_staff",
                principalTable: "Staff",
                principalColumn: "id_staff");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Staff_Task_id_task",
                table: "Task_Staff",
                column: "id_task",
                principalTable: "Task",
                principalColumn: "id_task");
        }
    }
}
