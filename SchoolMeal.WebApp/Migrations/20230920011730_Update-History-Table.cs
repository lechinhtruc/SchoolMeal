using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoCaoTienAn.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_mealmoney",
                table: "Tbl_mealmoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_account",
                table: "Tbl_account");

            migrationBuilder.RenameTable(
                name: "Tbl_mealmoney",
                newName: "Tbl_Mealmoney");

            migrationBuilder.RenameTable(
                name: "Tbl_account",
                newName: "Tbl_Account");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tbl_HistoryLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Tbl_HistoryLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Mealmoney",
                table: "Tbl_Mealmoney",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Account",
                table: "Tbl_Account",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Mealmoney",
                table: "Tbl_Mealmoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Account",
                table: "Tbl_Account");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tbl_HistoryLog");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Tbl_HistoryLog");

            migrationBuilder.RenameTable(
                name: "Tbl_Mealmoney",
                newName: "Tbl_mealmoney");

            migrationBuilder.RenameTable(
                name: "Tbl_Account",
                newName: "Tbl_account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_mealmoney",
                table: "Tbl_mealmoney",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_account",
                table: "Tbl_account",
                column: "Id");
        }
    }
}
