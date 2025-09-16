using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class NewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UnavailableDates",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "EndDate", "StartDate", "UnavailableDates" },
                values: new object[] { new DateOnly(1, 1, 1), new DateOnly(1, 1, 1), "[]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnavailableDates",
                table: "Products");
        }
    }
}
