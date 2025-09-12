using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DivingSuitId = table.Column<int>(type: "int", nullable: true),
                    FlipperId = table.Column<int>(type: "int", nullable: true),
                    RegulatorsetId = table.Column<int>(type: "int", nullable: true),
                    SnorkelSetId = table.Column<int>(type: "int", nullable: true),
                    TankId = table.Column<int>(type: "int", nullable: true),
                    DivingSuit_Size = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivingSuit_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SnorkelSet_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_DivingSuitId",
                        column: x => x.DivingSuitId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Products_FlipperId",
                        column: x => x.FlipperId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Products_RegulatorsetId",
                        column: x => x.RegulatorsetId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Products_SnorkelSetId",
                        column: x => x.SnorkelSetId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Products_TankId",
                        column: x => x.TankId,
                        principalTable: "Products",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "Discriminator", "DivingSuitId", "FlipperId", "ImagePath", "PricePerDay", "RegulatorsetId", "SnorkelSetId", "TankId" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Comfortable and durable BCD for all diving levels.", "Product", null, null, "lib/Public/BCDProduct.png", 125.0, null, null, null },
                    { 2, "Scubapro", "Comfortable and durable BCD for all diving levels.", "Product", null, null, "lib/Public/BCDProduct.png", 140.0, null, null, null },
                    { 3, "Scubapro", "Comfortable and durable BCD for all diving levels.", "Product", null, null, "lib/Public/BCDProduct.png", 200.0, null, null, null },
                    { 4, "Seac", "Comfortable and durable BCD for all diving levels.", "Product", null, null, "lib/Public/BCDProduct.png", 145.0, null, null, null }
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

            migrationBuilder.CreateIndex(
                name: "IX_BCDs_ProductId",
                table: "BCDs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DivingSuitId",
                table: "Products",
                column: "DivingSuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FlipperId",
                table: "Products",
                column: "FlipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RegulatorsetId",
                table: "Products",
                column: "RegulatorsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SnorkelSetId",
                table: "Products",
                column: "SnorkelSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TankId",
                table: "Products",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
