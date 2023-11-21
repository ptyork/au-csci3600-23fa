using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI3600.Migrations
{
    /// <inheritdoc />
    public partial class AddAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "GradeItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: true),
                    GradeCategoryCategoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_GradeItems_GradeCategories_GradeCategoryCategoryId",
                        column: x => x.GradeCategoryCategoryId,
                        principalTable: "GradeCategories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeItems_GradeCategoryCategoryId",
                table: "GradeItems",
                column: "GradeCategoryCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeItems");

            migrationBuilder.DropTable(
                name: "GradeCategories");
        }
    }
}
