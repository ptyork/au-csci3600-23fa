using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI3600.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeItems_GradeCategories_GradeCategoryCategoryId",
                table: "GradeItems");

            migrationBuilder.DropIndex(
                name: "IX_GradeItems_GradeCategoryCategoryId",
                table: "GradeItems");

            migrationBuilder.DropColumn(
                name: "GradeCategoryCategoryId",
                table: "GradeItems");

            migrationBuilder.AddColumn<Guid>(
                name: "GradeCategoryId",
                table: "GradeItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GradeItems_GradeCategoryId",
                table: "GradeItems",
                column: "GradeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeItems_GradeCategories_GradeCategoryId",
                table: "GradeItems",
                column: "GradeCategoryId",
                principalTable: "GradeCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeItems_GradeCategories_GradeCategoryId",
                table: "GradeItems");

            migrationBuilder.DropIndex(
                name: "IX_GradeItems_GradeCategoryId",
                table: "GradeItems");

            migrationBuilder.DropColumn(
                name: "GradeCategoryId",
                table: "GradeItems");

            migrationBuilder.AddColumn<Guid>(
                name: "GradeCategoryCategoryId",
                table: "GradeItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradeItems_GradeCategoryCategoryId",
                table: "GradeItems",
                column: "GradeCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeItems_GradeCategories_GradeCategoryCategoryId",
                table: "GradeItems",
                column: "GradeCategoryCategoryId",
                principalTable: "GradeCategories",
                principalColumn: "CategoryId");
        }
    }
}
