using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DeptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EmpFirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EmpLastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EmpDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpDeptID = table.Column<int>(type: "int", nullable: false),
                    EmpGrade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    EmpDesignation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpBasic = table.Column<int>(type: "int", nullable: false),
                    EmpGender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EmpMaritalStatus = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EmpHomeAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpContactNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "GradeMaster",
                columns: table => new
                {
                    GradeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MinSalary = table.Column<int>(type: "int", nullable: false),
                    MaxSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeMaster", x => x.GradeCode);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "GradeMaster");

            migrationBuilder.DropTable(
                name: "UserMaster");
        }
    }
}
