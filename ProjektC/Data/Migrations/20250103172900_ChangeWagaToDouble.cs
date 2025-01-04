using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWagaToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "waga",
                table: "Zwierze",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "waga",
                table: "Zwierze",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
