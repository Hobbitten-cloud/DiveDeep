using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class CustomerToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 30, 9, 14, 23, 560, DateTimeKind.Local).AddTicks(8708), new DateTime(2025, 10, 7, 9, 14, 23, 560, DateTimeKind.Local).AddTicks(8758) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 27, 55, 950, DateTimeKind.Local).AddTicks(5642), new DateTime(2025, 10, 6, 10, 27, 55, 950, DateTimeKind.Local).AddTicks(5714) });
        }
    }
}
