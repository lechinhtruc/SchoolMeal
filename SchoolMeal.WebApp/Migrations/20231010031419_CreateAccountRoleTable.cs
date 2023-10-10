using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoCaoTienAn.Migrations
{
    /// <inheritdoc />
    public partial class CreateAccountRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_AccountRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AccountRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_AccountRoles_Tbl_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Tbl_Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AccountRoles_AccountId",
                table: "Tbl_AccountRoles",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AccountRoles");
        }
    }
}
