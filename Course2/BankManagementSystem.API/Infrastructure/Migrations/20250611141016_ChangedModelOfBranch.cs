using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankManagementSystem.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModelOfBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branches",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Branches",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Branches",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Branches",
                newName: "Location");
        }
    }
}
