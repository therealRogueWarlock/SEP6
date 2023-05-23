using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestMovies.Migrations
{
    /// <inheritdoc />
    public partial class CommentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedEntity");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Favourite",
                newName: "SubjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedSubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedSubject_FanMovie_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "FanMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CommentId",
                table: "Review",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedSubject_ReferenceId",
                table: "LinkedSubject",
                column: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Comment_CommentId",
                table: "Review",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Comment_CommentId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "LinkedSubject");

            migrationBuilder.DropIndex(
                name: "IX_Review_CommentId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Favourite",
                newName: "EntityId");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LinkedEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedEntity_FanMovie_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "FanMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkedEntity_ReferenceId",
                table: "LinkedEntity",
                column: "ReferenceId");
        }
    }
}
