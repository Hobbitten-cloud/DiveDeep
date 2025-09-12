using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class NewNewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Products_DivingSuitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FlipperId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RegulatorsetId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SnorkelSetId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TankId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DivingSuitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FlipperId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RegulatorsetId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SnorkelSetId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Flippers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "DivingSuits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivingSuitId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlipperId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegulatorsetId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SnorkelSetId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Flippers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "DivingSuits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DivingSuitId", "FlipperId", "RegulatorsetId", "SnorkelSetId", "TankId" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DivingSuitId", "FlipperId", "RegulatorsetId", "SnorkelSetId", "TankId" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DivingSuitId", "FlipperId", "RegulatorsetId", "SnorkelSetId", "TankId" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DivingSuitId", "FlipperId", "RegulatorsetId", "SnorkelSetId", "TankId" },
                values: new object[] { null, null, null, null, null });

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
    }
}
