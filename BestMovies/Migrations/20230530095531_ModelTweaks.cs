using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestMovies.Migrations
{
    /// <inheritdoc />
    public partial class ModelTweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopIndex",
                table: "Favourite",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopIndex",
                table: "Favourite");
        }
    }
}
