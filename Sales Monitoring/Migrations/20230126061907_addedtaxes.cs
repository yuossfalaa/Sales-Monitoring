using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class addedtaxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TaxesPercentage",
                table: "Orders",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxesPercentage",
                table: "ItemSales",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxesPercentage",
                table: "Items",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxesPercentage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TaxesPercentage",
                table: "ItemSales");

            migrationBuilder.DropColumn(
                name: "TaxesPercentage",
                table: "Items");
        }
    }
}
