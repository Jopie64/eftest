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
                table: "Tests",
                newName: "NameChanged");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestToBeRemoved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestToBeRemoved");

            migrationBuilder.RenameColumn(
                name: "NameChanged",
                table: "Tests",
                newName: "Name");
        }
    }
}
