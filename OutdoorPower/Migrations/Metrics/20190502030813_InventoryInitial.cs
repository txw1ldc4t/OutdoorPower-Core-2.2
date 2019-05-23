using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations.Metrics
{
    public partial class InventoryInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QInventoryMake",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Display = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QInventoryMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QInventoryModelOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    QInventoryModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QInventoryModelOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QInventoryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QInventoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QInventoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Commercial = table.Column<bool>(nullable: false),
                    QInventoryMakeId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QInventoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QInventoryModel_QInventoryMake_QInventoryMakeId",
                        column: x => x.QInventoryMakeId,
                        principalTable: "QInventoryMake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QInventoryModel_QInventoryType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "QInventoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DealerId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                    QInventoryTypeId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    QInventoryMakeId = table.Column<int>(nullable: true),
                    QInventoryMakeOther = table.Column<string>(maxLength: 150, nullable: true),
                    QInventoryModelId = table.Column<int>(nullable: true),
                    QInventoryModelOther = table.Column<string>(maxLength: 100, nullable: true),
                    QInventoryModelOptionId = table.Column<int>(nullable: true),
                    QInventoryModelOptionOther = table.Column<string>(maxLength: 100, nullable: true),
                    EngineBrand = table.Column<string>(maxLength: 150, nullable: true),
                    EngineHorsePower = table.Column<string>(maxLength: 30, nullable: true),
                    EngineHours = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AmountSold = table.Column<decimal>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 15, nullable: true),
                    Fuel = table.Column<short>(nullable: false),
                    Condition = table.Column<short>(nullable: false),
                    WholeSalePrice = table.Column<decimal>(nullable: false),
                    PriceSold = table.Column<decimal>(nullable: false),
                    DateSold = table.Column<DateTime>(nullable: false),
                    DealerEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_QInventoryMake_QInventoryMakeId",
                        column: x => x.QInventoryMakeId,
                        principalTable: "QInventoryMake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_QInventoryModel_QInventoryModelId",
                        column: x => x.QInventoryModelId,
                        principalTable: "QInventoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_QInventoryModelOption_QInventoryModelOptionId",
                        column: x => x.QInventoryModelOptionId,
                        principalTable: "QInventoryModelOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_QInventoryType_QInventoryTypeId",
                        column: x => x.QInventoryTypeId,
                        principalTable: "QInventoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_QInventoryMakeId",
                table: "Inventories",
                column: "QInventoryMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_QInventoryModelId",
                table: "Inventories",
                column: "QInventoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_QInventoryModelOptionId",
                table: "Inventories",
                column: "QInventoryModelOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_QInventoryTypeId",
                table: "Inventories",
                column: "QInventoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QInventoryModel_QInventoryMakeId",
                table: "QInventoryModel",
                column: "QInventoryMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_QInventoryModel_TypeId",
                table: "QInventoryModel",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "QInventoryModel");

            migrationBuilder.DropTable(
                name: "QInventoryModelOption");

            migrationBuilder.DropTable(
                name: "QInventoryMake");

            migrationBuilder.DropTable(
                name: "QInventoryType");
        }
    }
}
