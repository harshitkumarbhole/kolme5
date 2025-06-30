using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Kolme.API.Data;

#nullable disable

namespace Kolme.API.Migrations
{
    [DbContext(typeof(KolmeDbContext))]
    [Migration("20240630000000_InitialCreate")]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    ReportingManagerId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportingManagerId",
                        column: x => x.ReportingManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLocationAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLocationAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLocationAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLocationAssignments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeModuleAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModuleAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeModuleAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeModuleAssignments_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoleAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoleAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoleAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoleAssignments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "Finance" },
                    { 3, "Engineering" },
                    { 4, "Sales" },
                    { 5, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Engineer" },
                    { 3, "Analyst" },
                    { 4, "Designer" },
                    { 5, "Consultant" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bengaluru" },
                    { 2, "Mumbai" },
                    { 3, "Delhi" },
                    { 4, "Chennai" },
                    { 5, "Hyderabad" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DivisionA" },
                    { 2, "DivisionB" },
                    { 3, "DivisionC" },
                    { 4, "DivisionD" },
                    { 5, "DivisionE" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ModuleA" },
                    { 2, "ModuleB" },
                    { 3, "ModuleC" },
                    { 4, "ModuleD" },
                    { 5, "ModuleE" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Manager" },
                    { 4, "Staff" },
                    { 5, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Document1" },
                    { 2, "Document2" },
                    { 3, "Document3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "AT/G9IR6v8qQIPHEVWXttkWvp7pe6CyX/57XTL+VWg3oTNnA6D9kfQCvy/f66zTBNg==", "user1" },
                    { 2, "AafM2hH9uXftvNzus2JY3NhbS5YQS3m0OwZqSGlcoFRmUw7fWzG0la7DrVhlLQuZgQ==", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[]
                {
                    "Id",
                    "Code",
                    "FirstName",
                    "LastName",
                    "Email",
                    "Phone",
                    "DepartmentId",
                    "JobTitleId",
                    "LocationId",
                    "DivisionId",
                    "ReportingManagerId",
                    "Gender",
                    "StartDate",
                    "EndDate",
                    "Status"
                },
                values: new object[,]
                {
                    { 1, "E001", "John", "Doe", "john@example.com", "1234567890", 1, 1, 1, 1, null, "Male", new DateTime(2020, 1, 1), null, "Active" },
                    { 2, "E002", "Jane", "Smith", "jane@example.com", "0987654321", 2, 2, 2, 2, 1, "Female", new DateTime(2021, 6, 1), null, "Active" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoleAssignments",
                columns: new[] { "Id", "EmployeeId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeModuleAssignments",
                columns: new[] { "Id", "EmployeeId", "ModuleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeLocationAssignments",
                columns: new[] { "Id", "EmployeeId", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DivisionId",
                table: "Employees",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportingManagerId",
                table: "Employees",
                column: "ReportingManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLocationAssignments_EmployeeId",
                table: "EmployeeLocationAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLocationAssignments_LocationId",
                table: "EmployeeLocationAssignments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModuleAssignments_EmployeeId",
                table: "EmployeeModuleAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModuleAssignments_ModuleId",
                table: "EmployeeModuleAssignments",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoleAssignments_EmployeeId",
                table: "EmployeeRoleAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoleAssignments_RoleId",
                table: "EmployeeRoleAssignments",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EmployeeLocationAssignments");
            migrationBuilder.DropTable(name: "EmployeeModuleAssignments");
            migrationBuilder.DropTable(name: "EmployeeRoleAssignments");
            migrationBuilder.DropTable(name: "Documents");
            migrationBuilder.DropTable(name: "Users");
            migrationBuilder.DropTable(name: "Employees");
            migrationBuilder.DropTable(name: "Modules");
            migrationBuilder.DropTable(name: "Roles");
            migrationBuilder.DropTable(name: "Departments");
            migrationBuilder.DropTable(name: "Divisions");
            migrationBuilder.DropTable(name: "JobTitles");
            migrationBuilder.DropTable(name: "Locations");
        }
    }
}

