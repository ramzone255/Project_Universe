using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Universe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractor_Company",
                columns: table => new
                {
                    id_contractor_company = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_contractor_company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description_contractor_company = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor_Company", x => x.id_contractor_company);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Company",
                columns: table => new
                {
                    id_customer_company = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_customer_company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description_customer_company = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Company", x => x.id_customer_company);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id_post);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    id_priority = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.id_priority);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    id_staff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patronymic_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_staff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_post = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.id_staff);
                    table.ForeignKey(
                        name: "FK_Staff_Post_id_post",
                        column: x => x.id_post,
                        principalTable: "Post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id_project = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_project = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_contractor_company = table.Column<int>(type: "int", nullable: false),
                    id_customer_company = table.Column<int>(type: "int", nullable: false),
                    id_priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id_project);
                    table.ForeignKey(
                        name: "FK_Project_Contractor_Company_id_contractor_company",
                        column: x => x.id_contractor_company,
                        principalTable: "Contractor_Company",
                        principalColumn: "id_contractor_company",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Customer_Company_id_customer_company",
                        column: x => x.id_customer_company,
                        principalTable: "Customer_Company",
                        principalColumn: "id_customer_company",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Priority_id_priority",
                        column: x => x.id_priority,
                        principalTable: "Priority",
                        principalColumn: "id_priority",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id_task = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_task = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    id_priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id_task);
                    table.ForeignKey(
                        name: "FK_Task_Priority_id_priority",
                        column: x => x.id_priority,
                        principalTable: "Priority",
                        principalColumn: "id_priority",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Status_id_status",
                        column: x => x.id_status,
                        principalTable: "Status",
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    id_staff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_User_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project_Task",
                columns: table => new
                {
                    id_project_task = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_task = table.Column<int>(type: "int", nullable: true),
                    id_project = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Task", x => x.id_project_task);
                    table.ForeignKey(
                        name: "FK_Project_Task_Project_id_project",
                        column: x => x.id_project,
                        principalTable: "Project",
                        principalColumn: "id_project");
                    table.ForeignKey(
                        name: "FK_Project_Task_Task_id_task",
                        column: x => x.id_task,
                        principalTable: "Task",
                        principalColumn: "id_task");
                });

            migrationBuilder.CreateTable(
                name: "Task_Staff",
                columns: table => new
                {
                    id_task_staff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_task = table.Column<int>(type: "int", nullable: true),
                    id_staff = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Staff", x => x.id_task_staff);
                    table.ForeignKey(
                        name: "FK_Task_Staff_Staff_id_staff",
                        column: x => x.id_staff,
                        principalTable: "Staff",
                        principalColumn: "id_staff");
                    table.ForeignKey(
                        name: "FK_Task_Staff_Task_id_task",
                        column: x => x.id_task,
                        principalTable: "Task",
                        principalColumn: "id_task");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_Company_id_contractor_company",
                table: "Contractor_Company",
                column: "id_contractor_company",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Company_id_customer_company",
                table: "Customer_Company",
                column: "id_customer_company",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_id_post",
                table: "Post",
                column: "id_post",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Priority_id_priority",
                table: "Priority",
                column: "id_priority",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_id_contractor_company",
                table: "Project",
                column: "id_contractor_company");

            migrationBuilder.CreateIndex(
                name: "IX_Project_id_customer_company",
                table: "Project",
                column: "id_customer_company");

            migrationBuilder.CreateIndex(
                name: "IX_Project_id_priority",
                table: "Project",
                column: "id_priority");

            migrationBuilder.CreateIndex(
                name: "IX_Project_id_project",
                table: "Project",
                column: "id_project",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_Task_id_project",
                table: "Project_Task",
                column: "id_project");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Task_id_project_task",
                table: "Project_Task",
                column: "id_project_task",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_Task_id_task",
                table: "Project_Task",
                column: "id_task");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_id_post",
                table: "Staff",
                column: "id_post");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_id_staff",
                table: "Staff",
                column: "id_staff",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_status",
                table: "Status",
                column: "id_status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_id_priority",
                table: "Task",
                column: "id_priority");

            migrationBuilder.CreateIndex(
                name: "IX_Task_id_status",
                table: "Task",
                column: "id_status");

            migrationBuilder.CreateIndex(
                name: "IX_Task_id_task",
                table: "Task",
                column: "id_task",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_Staff_id_staff",
                table: "Task_Staff",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Staff_id_task",
                table: "Task_Staff",
                column: "id_task");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Staff_id_task_staff",
                table: "Task_Staff",
                column: "id_task_staff",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_id_staff",
                table: "User",
                column: "id_staff");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_user",
                table: "User",
                column: "id_user",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_Task");

            migrationBuilder.DropTable(
                name: "Task_Staff");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Contractor_Company");

            migrationBuilder.DropTable(
                name: "Customer_Company");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
