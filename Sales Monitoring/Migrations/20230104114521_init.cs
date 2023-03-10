using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    ItemInstorePrice = table.Column<double>(type: "REAL", nullable: true),
                    ItemZomatoPrice = table.Column<double>(type: "REAL", nullable: true),
                    ItemSwiggyPrice = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    QtyInStore = table.Column<int>(type: "INTEGER", nullable: true),
                    InStoreSales = table.Column<double>(type: "REAL", nullable: true),
                    QtyZomato = table.Column<int>(type: "INTEGER", nullable: true),
                    ZomatoSales = table.Column<double>(type: "REAL", nullable: true),
                    QtySwiggy = table.Column<int>(type: "INTEGER", nullable: true),
                    SwiggySales = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Tax = table.Column<double>(type: "REAL", nullable: true),
                    Discount = table.Column<double>(type: "REAL", nullable: true),
                    Roundoff = table.Column<double>(type: "REAL", nullable: true),
                    TotalBill = table.Column<double>(type: "REAL", nullable: true),
                    Payment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecordExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderCollectionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderCollection_OrderCollectionId",
                        column: x => x.OrderCollectionId,
                        principalTable: "OrderCollection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderCollectionId",
                table: "Orders",
                column: "OrderCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemSales");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RecordExpenses");

            migrationBuilder.DropTable(
                name: "OrderCollection");
        }
    }
}
