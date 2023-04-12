using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTSTugas6.Migrations
{
    /// <inheritdoc />
    public partial class FixProfilingPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tb_m_educations_tb_m_universities_university_id",
                table: "TB_M_Educations");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_m_educations_tb_m_universities_university_id",
                table: "TB_M_Educations",
                column: "university_id",
                principalTable: "TB_M_Universities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tb_m_educations_tb_m_universities_university_id",
                table: "TB_M_Educations");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_m_educations_tb_m_universities_university_id",
                table: "TB_M_Educations",
                column: "university_id",
                principalTable: "TB_M_Universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
