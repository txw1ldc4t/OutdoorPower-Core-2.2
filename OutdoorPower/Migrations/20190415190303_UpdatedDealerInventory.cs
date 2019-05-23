using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class UpdatedDealerInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Condition",
                table: "DealerInventories",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "DealerInventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                table: "DealerInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineBrand",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineHorsePower",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineHours",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MakeOther",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelInfoId",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelOptionOther",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelOther",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OPTPublic",
                table: "DealerInventories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DealerInventories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QInventoryModelOptionId",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QInventoryTypeId",
                table: "DealerInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "DealerInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_DealerId",
                table: "DealerInventories",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_MakeId",
                table: "DealerInventories",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_ModelId",
                table: "DealerInventories",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_QInventoryModelOptionId",
                table: "DealerInventories",
                column: "QInventoryModelOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_QInventoryTypeId",
                table: "DealerInventories",
                column: "QInventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_Dealers_DealerId",
                table: "DealerInventories",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryMakes_MakeId",
                table: "DealerInventories",
                column: "MakeId",
                principalTable: "QInventoryMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryModels_ModelId",
                table: "DealerInventories",
                column: "ModelId",
                principalTable: "QInventoryModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryModelOptions_QInventoryModelOptionId",
                table: "DealerInventories",
                column: "QInventoryModelOptionId",
                principalTable: "QInventoryModelOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryTypes_QInventoryTypeId",
                table: "DealerInventories",
                column: "QInventoryTypeId",
                principalTable: "QInventoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_Dealers_DealerId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryMakes_MakeId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryModels_ModelId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryModelOptions_QInventoryModelOptionId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryTypes_QInventoryTypeId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_DealerId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_MakeId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_ModelId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_QInventoryModelOptionId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_QInventoryTypeId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "EngineBrand",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "EngineHorsePower",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "EngineHours",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "MakeOther",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "ModelInfoId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "ModelOptionOther",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "ModelOther",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "OPTPublic",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "QInventoryModelOptionId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "QInventoryTypeId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "DealerInventories");
        }
    }
}
