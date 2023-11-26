using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI3600.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedbackText",
                table: "Feedback",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Feedback",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Feedback",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Feedback");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Feedback",
                newName: "FeedbackText");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Feedback",
                newName: "EmailAddress");
        }
    }
}
