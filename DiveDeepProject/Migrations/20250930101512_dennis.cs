using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepProject.Migrations
{
    /// <inheritdoc />
    public partial class dennis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDivingCertificat = table.Column<bool>(type: "bit", nullable: false),
                    AcceptedTerms = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptPackage",
                columns: table => new
                {
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptPackage", x => new { x.PackagesId, x.ReceiptsId });
                    table.ForeignKey(
                        name: "FK_ReceiptPackage_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptPackage_Receipts_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ReceiptProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptProduct", x => new { x.ProductsId, x.ReceiptsId });
                    table.ForeignKey(
                        name: "FK_ReceiptProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptProduct_Receipts_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipts",
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "1", 0, "Nicklas Hus", "Nicklas By", "07e5730e-761d-4342-a785-8f1243122ccf", "Nicklas@gmail.com", false, false, null, "Nicklas Lover boy", null, null, null, "1-800-LoverBoy", false, "b9f86f38-4101-4c8a-bc2c-9dcb73f825f3", false, null, "3500" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "EndDate", "ImagePath", "Model", "PackageID", "PricePerDay", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", "Navigator Lite BCD", null, 125.0, new DateOnly(1, 1, 1), null },
                    { 2, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", "BCD Glide", null, 140.0, new DateOnly(1, 1, 1), null },
                    { 3, "Scubapro", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", "BCD Hydros Pro", null, 200.0, new DateOnly(1, 1, 1), null },
                    { 4, "Seac", "Comfortable and durable BCD for all diving levels.", new DateOnly(1, 1, 1), "lib/Public/BCDProduct.png", "BCD Modular", null, 145.0, new DateOnly(1, 1, 1), null },
                    { 5, "Scubapro", "3 mm wetsuit for warm water diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "Definition", null, 100.0, new DateOnly(1, 1, 1), null },
                    { 6, "Scubapro", "5 mm wetsuit for versatile diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "Definition", null, 100.0, new DateOnly(1, 1, 1), null },
                    { 7, "Scubapro", "7 mm wetsuit for colder waters.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "Definition", null, 100.0, new DateOnly(1, 1, 1), null },
                    { 8, "Waterproof", "3.5 mm wetsuit, flexible and warm.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "W5", null, 100.0, new DateOnly(1, 1, 1), null },
                    { 9, "Fourth Element", "5 mm premium wetsuit.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "Proteus", null, 120.0, new DateOnly(1, 1, 1), null },
                    { 10, "Scubapro", "Durable drysuit.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "Exodry 4.0", null, 300.0, new DateOnly(1, 1, 1), null },
                    { 11, "Waterproof", "Advanced drysuit for technical diving.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "D7 Evo", null, 320.0, new DateOnly(1, 1, 1), null },
                    { 12, "Santi", "Top-tier drysuit for professionals.", new DateOnly(1, 1, 1), "lib/Public/DivingSuitProduct.png", "E.Lite Plus", null, 350.0, new DateOnly(1, 1, 1), null },
                    { 13, "Scubapro", "Compact tank, good for short dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", "", null, 150.0, new DateOnly(1, 1, 1), null },
                    { 14, "Scubapro", "Standard tank for recreational diving.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", "", null, 160.0, new DateOnly(1, 1, 1), null },
                    { 15, "Scubapro", "Versatile tank, good for most dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", "", null, 170.0, new DateOnly(1, 1, 1), null },
                    { 16, "Scubapro", "Large tank for extended dives.", new DateOnly(1, 1, 1), "lib/Public/TankProduct.png", "", null, 180.0, new DateOnly(1, 1, 1), null },
                    { 17, "Scubapro", "High performance regulator.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", "MK25EVO", null, 125.0, new DateOnly(1, 1, 1), null },
                    { 18, "Scubapro", "Reliable regulator set.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", "MK17EVO", null, 100.0, new DateOnly(1, 1, 1), null },
                    { 19, "Scubapro", "Top-tier regulator with carbon second stage.", new DateOnly(1, 1, 1), "lib/Public/RegulatorSetProduct.png", "MK25EVO BT", null, 150.0, new DateOnly(1, 1, 1), null },
                    { 20, "Scubapro", "Frameless mask with wide view.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Ghost", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 21, "Scubapro", "Premium diving mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "D-Mask", null, 60.0, new DateOnly(1, 1, 1), null },
                    { 22, "Scubapro", "Compact mask for smaller faces.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Spectra Mini", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 23, "Scubapro", "Wide field of view mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Crystal VU", null, 75.0, new DateOnly(1, 1, 1), null },
                    { 24, "Fourth Element", "Advanced mask for all conditions.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Scout Kontrast", null, 75.0, new DateOnly(1, 1, 1), null },
                    { 25, "Fourth Element", "High clarity mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Scout Enhance", null, 75.0, new DateOnly(1, 1, 1), null },
                    { 26, "Tusa", "Durable and clear diving mask.", new DateOnly(1, 1, 1), "lib/Public/MaskProduct.png", "Element", null, 75.0, new DateOnly(1, 1, 1), null },
                    { 27, "Scubapro", "Classic durable fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "Jet Fin", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 28, "Scubapro", "Lightweight travel fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "GO Travel", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 29, "Scubapro", "High performance split fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "Seawing Supernova", null, 60.0, new DateOnly(1, 1, 1), null },
                    { 30, "Seac", "Durable and powerful fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "Propulsion", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 31, "Seac", "Compact and flexible fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "ALA", null, 50.0, new DateOnly(1, 1, 1), null },
                    { 32, "Fourth Element", "Strong fin for technical diving.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "Tech", null, 75.0, new DateOnly(1, 1, 1), null },
                    { 33, "Fourth Element", "All-round recreational fin.", new DateOnly(1, 1, 1), "lib/Public/FinsProduct.png", "Rec Fin", null, 80.0, new DateOnly(1, 1, 1), null }
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
                table: "Receipts",
                columns: new[] { "Id", "AcceptedTerms", "Comment", "HasDivingCertificat", "PickupDate", "ReturnDate", "Total", "UserId" },
                values: new object[] { 1, false, "First receipt", false, new DateTime(2025, 9, 30, 12, 15, 11, 839, DateTimeKind.Local).AddTicks(1948), new DateTime(2025, 10, 7, 12, 15, 11, 839, DateTimeKind.Local).AddTicks(2012), 500.0, "1" });

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Products_PackageID",
                table: "Products",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPackage_ReceiptsId",
                table: "ReceiptPackage",
                column: "ReceiptsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptProduct_ReceiptsId",
                table: "ReceiptProduct",
                column: "ReceiptsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts",
                column: "UserId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BCDs");

            migrationBuilder.DropTable(
                name: "DivingSuits");

            migrationBuilder.DropTable(
                name: "Flippers");

            migrationBuilder.DropTable(
                name: "ReceiptPackage");

            migrationBuilder.DropTable(
                name: "ReceiptProduct");

            migrationBuilder.DropTable(
                name: "Regulatorsets");

            migrationBuilder.DropTable(
                name: "SnorkelSets");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "UnavailableDates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
