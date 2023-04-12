using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTSTugas6.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_M_Roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -2, "Admin" },
                    { -1, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_M_Roles",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TB_M_Roles",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
