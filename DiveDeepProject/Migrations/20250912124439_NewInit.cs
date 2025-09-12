using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_DivingSuitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_FlipperId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_RegulatorsetId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_SnorkelSetId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_TankId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DivingSuit_Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DivingSuit_Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstStep",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Octopus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecondStep",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SnorkelSet_Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Thickness",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "DivingSuits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingSuits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flippers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regulatorsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    FirstStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondStep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulatorsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnorkelSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnorkelSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DivingSuits_DivingSuitId",
                table: "Products",
                column: "DivingSuitId",
                principalTable: "DivingSuits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Flippers_FlipperId",
                table: "Products",
                column: "FlipperId",
                principalTable: "Flippers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Regulatorsets_RegulatorsetId",
                table: "Products",
                column: "RegulatorsetId",
                principalTable: "Regulatorsets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SnorkelSets_SnorkelSetId",
                table: "Products",
                column: "SnorkelSetId",
                principalTable: "SnorkelSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tanks_TankId",
                table: "Products",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DivingSuits_DivingSuitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Flippers_FlipperId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Regulatorsets_RegulatorsetId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SnorkelSets_SnorkelSetId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tanks_TankId",
                table: "Products");

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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DivingSuit_Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivingSuit_Size",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstStep",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Octopus",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondStep",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SnorkelSet_Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thickness",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Volume",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_DivingSuitId",
                table: "Products",
                column: "DivingSuitId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_FlipperId",
                table: "Products",
                column: "FlipperId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_RegulatorsetId",
                table: "Products",
                column: "RegulatorsetId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_SnorkelSetId",
                table: "Products",
                column: "SnorkelSetId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_TankId",
                table: "Products",
                column: "TankId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
