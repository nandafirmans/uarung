using Microsoft.EntityFrameworkCore.Migrations;

namespace Uarung.API.Migrations
{
    public partial class RenamingImageAndSelectedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedProductId",
                table: "SelectedProducts",
                newName: "SelectedId");

            migrationBuilder.RenameColumn(
                name: "ProductImageId",
                table: "ProductImages",
                newName: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedId",
                table: "SelectedProducts",
                newName: "SelectedProductId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "ProductImages",
                newName: "ProductImageId");
        }
    }
}
