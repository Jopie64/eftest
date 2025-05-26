using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eftest.migrations
{
    /// <inheritdoc />
    public partial class ChangeTableToBeRemovedLater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestToBeRemoved",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestToBeRemoved");
        }
    }
}
