using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTSTugas6.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGPAToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_roles_role_id",
                table: "TB_TR_Account_Roles");

            migrationBuilder.AlterColumn<decimal>(
                name: "gpa",
                table: "TB_M_Educations",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik",
                principalTable: "TB_M_Accounts",
                principalColumn: "employee_nik");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id",
                principalTable: "TB_M_Roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "TB_TR_Account_Roles");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_roles_role_id",
                table: "TB_TR_Account_Roles");

            migrationBuilder.AlterColumn<string>(
                name: "gpa",
                table: "TB_M_Educations",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "TB_TR_Account_Roles",
                column: "account_nik",
                principalTable: "TB_M_Accounts",
                principalColumn: "employee_nik",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_tr_account_roles_tb_m_roles_role_id",
                table: "TB_TR_Account_Roles",
                column: "role_id",
                principalTable: "TB_M_Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
