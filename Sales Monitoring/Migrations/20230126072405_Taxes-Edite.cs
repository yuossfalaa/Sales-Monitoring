using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class TaxesEdite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxesPercentage",
                table: "ItemSales",
                newName: "Taxes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Taxes",
                table: "ItemSales",
                newName: "TaxesPercentage");
        }
    }
}
