using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmIt.Migrations
{
    /// <inheritdoc />
    public partial class farm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "TvSeries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "TvSeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
