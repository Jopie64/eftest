using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eftest.migrations
{
    /// <inheritdoc />
    public partial class ChangeBothTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SomeValue",
                table: "TestToBeRemoved",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SomeValue",
                table: "Tests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomeValue",
                table: "TestToBeRemoved");

            migrationBuilder.DropColumn(
                name: "SomeValue",
                table: "Tests");
        }
    }
}
