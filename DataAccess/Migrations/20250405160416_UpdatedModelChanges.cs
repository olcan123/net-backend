using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IsoftAccount_Companies_CompanyId",
                table: "IsoftAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IsoftAccount",
                table: "IsoftAccount");

            migrationBuilder.RenameTable(
                name: "IsoftAccount",
                newName: "IsoftAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_IsoftAccount_CompanyId",
                table: "IsoftAccounts",
                newName: "IX_IsoftAccounts_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IsoftAccounts",
                table: "IsoftAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IsoftAccounts_Companies_CompanyId",
                table: "IsoftAccounts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IsoftAccounts_Companies_CompanyId",
                table: "IsoftAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IsoftAccounts",
                table: "IsoftAccounts");

            migrationBuilder.RenameTable(
                name: "IsoftAccounts",
                newName: "IsoftAccount");

            migrationBuilder.RenameIndex(
                name: "IX_IsoftAccounts_CompanyId",
                table: "IsoftAccount",
                newName: "IX_IsoftAccount_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IsoftAccount",
                table: "IsoftAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IsoftAccount_Companies_CompanyId",
                table: "IsoftAccount",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
