using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class AllDataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "SnorkelSets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SnorkelSets");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "SnorkelSets");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "SnorkelSets");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Regulatorsets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Regulatorsets");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Regulatorsets");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Regulatorsets");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Flippers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Flippers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Flippers");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Flippers");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "DivingSuits");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "DivingSuits");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SnorkelSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Regulatorsets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Flippers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "DivingSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "ImagePath", "PricePerDay" },
                values: new object[,]
                {
                    { 5, "Scubapro", "3 mm wetsuit for warm water diving.", "lib/Public/DivingSuitProduct.png", 100.0 },
                    { 6, "Scubapro", "5 mm wetsuit for versatile diving.", "lib/Public/DivingSuitProduct.png", 100.0 },
                    { 7, "Scubapro", "7 mm wetsuit for colder waters.", "lib/Public/DivingSuitProduct.png", 100.0 },
                    { 8, "Waterproof", "3.5 mm wetsuit, flexible and warm.", "lib/Public/DivingSuitProduct.png", 100.0 },
                    { 9, "Fourth Element", "5 mm premium wetsuit.", "lib/Public/DivingSuitProduct.png", 120.0 },
                    { 10, "Scubapro", "Durable drysuit.", "lib/Public/DivingSuitProduct.png", 300.0 },
                    { 11, "Waterproof", "Advanced drysuit for technical diving.", "lib/Public/DivingSuitProduct.png", 320.0 },
                    { 12, "Santi", "Top-tier drysuit for professionals.", "lib/Public/DivingSuitProduct.png", 350.0 },
                    { 13, "Scubapro", "Compact tank, good for short dives.", "lib/Public/TankProduct.png", 150.0 },
                    { 14, "Scubapro", "Standard tank for recreational diving.", "lib/Public/TankProduct.png", 160.0 },
                    { 15, "Scubapro", "Versatile tank, good for most dives.", "lib/Public/TankProduct.png", 170.0 },
                    { 16, "Scubapro", "Large tank for extended dives.", "lib/Public/TankProduct.png", 180.0 },
                    { 17, "Scubapro", "High performance regulator.", "lib/Public/RegulatorSetProduct.png", 125.0 },
                    { 18, "Scubapro", "Reliable regulator set.", "lib/Public/RegulatorSetProduct.png", 100.0 },
                    { 19, "Scubapro", "Top-tier regulator with carbon second stage.", "lib/Public/RegulatorSetProduct.png", 150.0 },
                    { 20, "Scubapro", "Frameless mask with wide view.", "lib/Public/MaskProduct.png", 50.0 },
                    { 21, "Scubapro", "Premium diving mask.", "lib/Public/MaskProduct.png", 60.0 },
                    { 22, "Scubapro", "Compact mask for smaller faces.", "lib/Public/MaskProduct.png", 50.0 },
                    { 23, "Scubapro", "Wide field of view mask.", "lib/Public/MaskProduct.png", 75.0 },
                    { 24, "Fourth Element", "Advanced mask for all conditions.", "lib/Public/MaskProduct.png", 75.0 },
                    { 25, "Fourth Element", "High clarity mask.", "lib/Public/MaskProduct.png", 75.0 },
                    { 26, "Tusa", "Durable and clear diving mask.", "lib/Public/MaskProduct.png", 75.0 },
                    { 27, "Scubapro", "Classic durable fin.", "lib/Public/FinsProduct.png", 50.0 },
                    { 28, "Scubapro", "Lightweight travel fin.", "lib/Public/FinsProduct.png", 50.0 },
                    { 29, "Scubapro", "High performance split fin.", "lib/Public/FinsProduct.png", 60.0 },
                    { 30, "Seac", "Durable and powerful fin.", "lib/Public/FinsProduct.png", 50.0 },
                    { 31, "Seac", "Compact and flexible fin.", "lib/Public/FinsProduct.png", 50.0 },
                    { 32, "Fourth Element", "Strong fin for technical diving.", "lib/Public/FinsProduct.png", 75.0 },
                    { 33, "Fourth Element", "All-round recreational fin.", "lib/Public/FinsProduct.png", 80.0 }
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
                name: "IX_Tanks_ProductId",
                table: "Tanks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SnorkelSets_ProductId",
                table: "SnorkelSets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulatorsets_ProductId",
                table: "Regulatorsets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Flippers_ProductId",
                table: "Flippers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingSuits_ProductId",
                table: "DivingSuits",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DivingSuits_Products_ProductId",
                table: "DivingSuits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flippers_Products_ProductId",
                table: "Flippers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regulatorsets_Products_ProductId",
                table: "Regulatorsets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SnorkelSets_Products_ProductId",
                table: "SnorkelSets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Products_ProductId",
                table: "Tanks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivingSuits_Products_ProductId",
                table: "DivingSuits");

            migrationBuilder.DropForeignKey(
                name: "FK_Flippers_Products_ProductId",
                table: "Flippers");

            migrationBuilder.DropForeignKey(
                name: "FK_Regulatorsets_Products_ProductId",
                table: "Regulatorsets");

            migrationBuilder.DropForeignKey(
                name: "FK_SnorkelSets_Products_ProductId",
                table: "SnorkelSets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Products_ProductId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_ProductId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_SnorkelSets_ProductId",
                table: "SnorkelSets");

            migrationBuilder.DropIndex(
                name: "IX_Regulatorsets_ProductId",
                table: "Regulatorsets");

            migrationBuilder.DropIndex(
                name: "IX_Flippers_ProductId",
                table: "Flippers");

            migrationBuilder.DropIndex(
                name: "IX_DivingSuits_ProductId",
                table: "DivingSuits");

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DivingSuits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flippers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Regulatorsets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regulatorsets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regulatorsets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SnorkelSets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tanks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SnorkelSets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Regulatorsets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Flippers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DivingSuits");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "Tanks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "SnorkelSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SnorkelSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "SnorkelSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "SnorkelSets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Regulatorsets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Regulatorsets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Regulatorsets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "Regulatorsets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Flippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Flippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Flippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "Flippers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "DivingSuits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DivingSuits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "DivingSuits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "DivingSuits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
