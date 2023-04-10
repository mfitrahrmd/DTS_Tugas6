using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTSTugas6.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Employees",
                columns: table => new
                {
                    nik = table.Column<string>(type: "char(5)", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(50)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(50)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hiringdate = table.Column<DateTime>(name: "hiring_date", type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_m_employees", x => x.nik);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Universities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_m_universities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Accounts",
                columns: table => new
                {
                    employeenik = table.Column<string>(name: "employee_nik", type: "char(5)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_m_accounts", x => x.employeenik);
                    table.ForeignKey(
                        name: "fk_tb_m_accounts_tb_m_employees_employee_nik",
                        column: x => x.employeenik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Educations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major = table.Column<string>(type: "varchar(100)", nullable: false),
                    degree = table.Column<string>(type: "varchar(10)", nullable: false),
                    gpa = table.Column<string>(type: "varchar(5)", nullable: false),
                    universityid = table.Column<int>(name: "university_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_m_educations", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_m_educations_tb_m_universities_university_id",
                        column: x => x.universityid,
                        principalTable: "TB_M_Universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Account_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountnik = table.Column<string>(name: "account_nik", type: "char(5)", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_tr_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_tr_account_roles_tb_m_accounts_account_nik",
                        column: x => x.accountnik,
                        principalTable: "TB_M_Accounts",
                        principalColumn: "employee_nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tb_tr_account_roles_tb_m_roles_role_id",
                        column: x => x.roleid,
                        principalTable: "TB_M_Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Profilings",
                columns: table => new
                {
                    employeenik = table.Column<string>(name: "employee_nik", type: "char(5)", nullable: false),
                    educationid = table.Column<int>(name: "education_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_tr_profilings", x => x.employeenik);
                    table.ForeignKey(
                        name: "fk_tb_tr_profilings_tb_m_educations_education_id",
                        column: x => x.educationid,
                        principalTable: "TB_M_Educations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tb_tr_profilings_tb_m_employees_employee_nik",
                        column: x => x.employeenik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tb_m_educations_university_id",
                table: "TB_M_Educations",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_tb_m_employees_email",
                table: "TB_M_Employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tb_m_employees_phone_number",
                table: "TB_M_Employees",
                column: "phone_number",
                unique: true,
                filter: "[phone_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_tb_tr_account_roles_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "ix_tb_tr_account_roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_tb_tr_profilings_education_id",
                table: "TB_TR_Profilings",
                column: "education_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TR_Account_Roles");

            migrationBuilder.DropTable(
                name: "TB_TR_Profilings");

            migrationBuilder.DropTable(
                name: "TB_M_Accounts");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");

            migrationBuilder.DropTable(
                name: "TB_M_Educations");

            migrationBuilder.DropTable(
                name: "TB_M_Employees");

            migrationBuilder.DropTable(
                name: "TB_M_Universities");
        }
    }
}
