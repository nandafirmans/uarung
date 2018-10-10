using Microsoft.EntityFrameworkCore.Migrations;

namespace Uarung.API.Migrations
{
    public partial class UpdateTableTransactionAndSelectedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SelectedProducts",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "SelectedProducts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SelectedProducts");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "SelectedProducts");
        }
    }
}
