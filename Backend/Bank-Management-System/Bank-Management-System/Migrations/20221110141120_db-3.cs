using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "UserInformation",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "0.0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "UserInformation",
                type: "float",
                nullable: false,
                defaultValueSql: "0.0",
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
