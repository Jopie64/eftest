﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eftest.migrations
{
    /// <inheritdoc />
    public partial class RemoveTestToBeRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestToBeRemoved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestToBeRemoved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestToBeRemoved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestToBeRemoved_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestToBeRemoved_TestId",
                table: "TestToBeRemoved",
                column: "TestId");
        }
    }
}
