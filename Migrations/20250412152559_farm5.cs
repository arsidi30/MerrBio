using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmIt.Migrations
{
    /// <inheritdoc />
    public partial class farm5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Product");

            

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Product",
                newName: "MovieImage");

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseYear",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MovieCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategory", x => x.Id);
                });
        }
    }
}
