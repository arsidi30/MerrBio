using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmIt.Migrations
{
    /// <inheritdoc />
    public partial class ferma6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmriIFermerit",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmriIFermerit",
                table: "Product");
        }
    }
}
