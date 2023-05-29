using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddDecriptionToLinkedSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LinkedSubject",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LinkedSubject");
        }
    }
}
