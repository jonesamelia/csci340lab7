using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesGame.Migrations
{
    /// <inheritdoc />
    public partial class platform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Game",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Game");
        }
    }
}
