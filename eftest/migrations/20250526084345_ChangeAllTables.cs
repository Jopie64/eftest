using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eftest.migrations
{
    /// <inheritdoc />
    public partial class ChangeAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TestToBeRemoved",
                newName: "NameChanged");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tests",
                newName: "NameChanged");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameChanged",
                table: "TestToBeRemoved",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameChanged",
                table: "Tests",
                newName: "Name");
        }
    }
}
