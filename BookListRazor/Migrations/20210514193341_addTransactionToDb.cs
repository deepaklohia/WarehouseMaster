using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMaster.Migrations
{
    public partial class addTransactionToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "DailyTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionInAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionOutAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTransaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorId = table.Column<int>(type: "int", nullable: false),
                    vendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productMargin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productSellingPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionInvoiceRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryInUnit = table.Column<int>(type: "int", nullable: false),
                    InventoryOutUnit = table.Column<int>(type: "int", nullable: false),
                    InventoryBalUnit = table.Column<int>(type: "int", nullable: false),
                    ProductCostPricePU = table.Column<double>(type: "float", nullable: false),
                    ProductSellingPricePU = table.Column<double>(type: "float", nullable: false),
                    InvBalCostPriceTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    vendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vendorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.vendorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DailyTransaction");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
