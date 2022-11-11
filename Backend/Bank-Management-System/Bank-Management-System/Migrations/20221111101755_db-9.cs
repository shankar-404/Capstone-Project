using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class db9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankBrank",
                table: "LoanInfoTable",
                newName: "BankBranch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankBranch",
                table: "LoanInfoTable",
                newName: "BankBrank");
        }
    }
}
