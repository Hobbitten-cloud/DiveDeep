using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BCDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BCDs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivingSuits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingSuits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivingSuits_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flippers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flippers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flippers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regulatorsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulatorsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regulatorsets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnorkelSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnorkelSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnorkelSets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnavailableDates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnavailableDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailableDates", x => x.id);
                    table.ForeignKey(
                        name: "FK_UnavailableDates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "EndDate", "ImagePath", "PricePerDay", "StartDate" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", 125.0, new DateOnly(1, 1, 1) },
                    { 2, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", 140.0, new DateOnly(1, 1, 1) },
                    { 3, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", 200.0, new DateOnly(1, 1, 1) },
                    { 4, "Seac", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", 145.0, new DateOnly(1, 1, 1) },
                    { 5, "Scubapro", "3 mm wetsuit for warm water diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 100.0, new DateOnly(1, 1, 1) },
                    { 6, "Scubapro", "5 mm wetsuit for versatile diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 100.0, new DateOnly(1, 1, 1) },
                    { 7, "Scubapro", "7 mm wetsuit for colder waters.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 100.0, new DateOnly(1, 1, 1) },
                    { 8, "Waterproof", "3.5 mm wetsuit, flexible and warm.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 100.0, new DateOnly(1, 1, 1) },
                    { 9, "Fourth Element", "5 mm premium wetsuit.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 120.0, new DateOnly(1, 1, 1) },
                    { 10, "Scubapro", "Durable drysuit.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 300.0, new DateOnly(1, 1, 1) },
                    { 11, "Waterproof", "Advanced drysuit for technical diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 320.0, new DateOnly(1, 1, 1) },
                    { 12, "Santi", "Top-tier drysuit for professionals.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", 350.0, new DateOnly(1, 1, 1) },
                    { 13, "Scubapro", "Compact tank, good for short dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", 150.0, new DateOnly(1, 1, 1) },
                    { 14, "Scubapro", "Standard tank for recreational diving.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", 160.0, new DateOnly(1, 1, 1) },
                    { 15, "Scubapro", "Versatile tank, good for most dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", 170.0, new DateOnly(1, 1, 1) },
                    { 16, "Scubapro", "Large tank for extended dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", 180.0, new DateOnly(1, 1, 1) },
                    { 17, "Scubapro", "High performance regulator.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", 125.0, new DateOnly(1, 1, 1) },
                    { 18, "Scubapro", "Reliable regulator set.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", 100.0, new DateOnly(1, 1, 1) },
                    { 19, "Scubapro", "Top-tier regulator with carbon second stage.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", 150.0, new DateOnly(1, 1, 1) },
                    { 20, "Scubapro", "Frameless mask with wide view.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 21, "Scubapro", "Premium diving mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 60.0, new DateOnly(1, 1, 1) },
                    { 22, "Scubapro", "Compact mask for smaller faces.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 23, "Scubapro", "Wide field of view mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 75.0, new DateOnly(1, 1, 1) },
                    { 24, "Fourth Element", "Advanced mask for all conditions.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 75.0, new DateOnly(1, 1, 1) },
                    { 25, "Fourth Element", "High clarity mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 75.0, new DateOnly(1, 1, 1) },
                    { 26, "Tusa", "Durable and clear diving mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", 75.0, new DateOnly(1, 1, 1) },
                    { 27, "Scubapro", "Classic durable fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 28, "Scubapro", "Lightweight travel fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 29, "Scubapro", "High performance split fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 60.0, new DateOnly(1, 1, 1) },
                    { 30, "Seac", "Durable and powerful fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 31, "Seac", "Compact and flexible fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 50.0, new DateOnly(1, 1, 1) },
                    { 32, "Fourth Element", "Strong fin for technical diving.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 75.0, new DateOnly(1, 1, 1) },
                    { 33, "Fourth Element", "All-round recreational fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", 80.0, new DateOnly(1, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "BCDs",
                columns: new[] { "Id", "Model", "ProductId", "Size" },
                values: new object[,]
                {
                    { 1, "Navigator Lite BCD", 1, null },
                    { 2, "BCD Glide", 2, null },
                    { 3, "BCD Hydros Pro", 3, null },
                    { 4, "BCD Modular", 4, null }
                });

            migrationBuilder.InsertData(
                table: "DivingSuits",
                columns: new[] { "Id", "Gender", "Model", "ProductId", "Size", "Thickness", "Type" },
                values: new object[,]
                {
                    { 1, 0, "Definition", 5, null, "3 mm", "Våddragt" },
                    { 2, 0, "Definition", 6, null, "5 mm", "Våddragt" },
                    { 3, 0, "Definition", 7, null, "7 mm", "Våddragt" },
                    { 4, 0, "W5", 8, null, "3.5 mm", "Våddragt" },
                    { 5, 0, "Proteus", 9, null, "5 mm", "Våddragt" },
                    { 6, 0, "Exodry 4.0", 10, null, "N/A", "Tørdragt" },
                    { 7, 0, "D7 Evo", 11, null, "N/A", "Tørdragt" },
                    { 8, 0, "E.Lite Plus", 12, null, "N/A", "Tørdragt" }
                });

            migrationBuilder.InsertData(
                table: "Flippers",
                columns: new[] { "Id", "Model", "ProductId", "Size" },
                values: new object[,]
                {
                    { 1, "Jet Fin", 27, null },
                    { 2, "GO Travel", 28, null },
                    { 3, "Seawing Supernova", 29, null },
                    { 4, "Propulsion", 30, null },
                    { 5, "ALA", 31, null },
                    { 6, "Tech", 32, null },
                    { 7, "Rec Fin", 33, null }
                });

            migrationBuilder.InsertData(
                table: "Regulatorsets",
                columns: new[] { "Id", "FirstStep", "Octopus", "ProductId", "SecondStep" },
                values: new object[,]
                {
                    { 1, "MK25EVO", "R105", 17, "S600" },
                    { 2, "MK17EVO", "R095", 18, "C370" },
                    { 3, "MK25EVO BT", "S270", 19, "A700 Carbon BT" }
                });

            migrationBuilder.InsertData(
                table: "SnorkelSets",
                columns: new[] { "Id", "Model", "ProductId" },
                values: new object[,]
                {
                    { 1, "Ghost", 20 },
                    { 2, "D-Mask", 21 },
                    { 3, "Spectra Mini", 22 },
                    { 4, "Crystal VU", 23 },
                    { 5, "Scout Kontrast", 24 },
                    { 6, "Scout Enhance", 25 },
                    { 7, "Element", 26 }
                });

            migrationBuilder.InsertData(
                table: "Tanks",
                columns: new[] { "Id", "ProductId", "Volume" },
                values: new object[,]
                {
                    { 1, 13, "5 L" },
                    { 2, 14, "10 L" },
                    { 3, 15, "12 L" },
                    { 4, 16, "15 L" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BCDs_ProductId",
                table: "BCDs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingSuits_ProductId",
                table: "DivingSuits",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Flippers_ProductId",
                table: "Flippers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulatorsets_ProductId",
                table: "Regulatorsets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SnorkelSets_ProductId",
                table: "SnorkelSets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ProductId",
                table: "Tanks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailableDates_ProductId",
                table: "UnavailableDates",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "DivingSuits");

            migrationBuilder.DropTable(
                name: "Flippers");

            migrationBuilder.DropTable(
                name: "Regulatorsets");

            migrationBuilder.DropTable(
                name: "SnorkelSets");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "UnavailableDates");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
