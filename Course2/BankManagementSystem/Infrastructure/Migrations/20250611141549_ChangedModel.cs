using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_Nickname",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "People",
                newName: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserName",
                table: "People",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_UserName",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "People",
                newName: "Nickname");

            migrationBuilder.CreateIndex(
                name: "IX_People_Nickname",
                table: "People",
                column: "Nickname",
                unique: true,
                filter: "[Nickname] IS NOT NULL");
        }
    }
}
