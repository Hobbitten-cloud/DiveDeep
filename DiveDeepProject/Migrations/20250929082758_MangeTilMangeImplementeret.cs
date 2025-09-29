using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class MangeTilMangeImplementeret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptPackage_Packages_PackagesTestId",
                table: "ReceiptPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Products_ProductsTestId",
                table: "ReceiptProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsTestId",
                table: "ReceiptProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "PackagesTestId",
                table: "ReceiptPackage",
                newName: "PackagesId");

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 27, 55, 950, DateTimeKind.Local).AddTicks(5642), new DateTime(2025, 10, 6, 10, 27, 55, 950, DateTimeKind.Local).AddTicks(5714) });

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptPackage_Packages_PackagesId",
                table: "ReceiptPackage",
                column: "PackagesId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Products_ProductsId",
                table: "ReceiptProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptPackage_Packages_PackagesId",
                table: "ReceiptPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptProduct_Products_ProductsId",
                table: "ReceiptProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ReceiptProduct",
                newName: "ProductsTestId");

            migrationBuilder.RenameColumn(
                name: "PackagesId",
                table: "ReceiptPackage",
                newName: "PackagesTestId");

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 24, 14, 860, DateTimeKind.Local).AddTicks(821), new DateTime(2025, 10, 6, 10, 24, 14, 860, DateTimeKind.Local).AddTicks(896) });

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptPackage_Packages_PackagesTestId",
                table: "ReceiptPackage",
                column: "PackagesTestId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptProduct_Products_ProductsTestId",
                table: "ReceiptProduct",
                column: "ProductsTestId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
