using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class db5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccounList_UserInformation_UserInfoId",
                table: "AccounList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccounList",
                table: "AccounList");

            migrationBuilder.DropIndex(
                name: "IX_AccounList_UserInfoId",
                table: "AccounList");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "AccounList");

            migrationBuilder.RenameTable(
                name: "AccounList",
                newName: "AccountList");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "AccountList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountList",
                table: "AccountList",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountList",
                table: "AccountList");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AccountList");

            migrationBuilder.RenameTable(
                name: "AccountList",
                newName: "AccounList");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "UserInformation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "AccounList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccounList",
                table: "AccounList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccounList_UserInfoId",
                table: "AccounList",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccounList_UserInformation_UserInfoId",
                table: "AccounList",
                column: "UserInfoId",
                principalTable: "UserInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
