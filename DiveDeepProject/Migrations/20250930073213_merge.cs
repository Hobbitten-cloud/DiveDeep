using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class merge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 30, 9, 32, 12, 125, DateTimeKind.Local).AddTicks(5534), new DateTime(2025, 10, 7, 9, 32, 12, 125, DateTimeKind.Local).AddTicks(5578) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PickupDate", "ReturnDate" },
                values: new object[] { new DateTime(2025, 9, 30, 9, 14, 23, 560, DateTimeKind.Local).AddTicks(8708), new DateTime(2025, 10, 7, 9, 14, 23, 560, DateTimeKind.Local).AddTicks(8758) });
        }
    }
}
