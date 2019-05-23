using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class DealerInventoryColumnNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryMakes_MakeId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryModels_ModelId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_MakeId",
                table: "DealerInventories");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "DealerInventories");

            migrationBuilder.RenameColumn(
                name: "ModelOther",
                table: "DealerInventories",
                newName: "QInventoryModelOther");

            migrationBuilder.RenameColumn(
                name: "ModelOptionOther",
                table: "DealerInventories",
                newName: "QInventoryModelOptionOther");

            migrationBuilder.RenameColumn(
                name: "ModelInfoId",
                table: "DealerInventories",
                newName: "QInventoryModelId");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "DealerInventories",
                newName: "QInventoryMakeId");

            migrationBuilder.RenameColumn(
                name: "MakeOther",
                table: "DealerInventories",
                newName: "QInventoryMakeOther");

            migrationBuilder.RenameIndex(
                name: "IX_DealerInventories_ModelId",
                table: "DealerInventories",
                newName: "IX_DealerInventories_QInventoryMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_QInventoryModelId",
                table: "DealerInventories",
                column: "QInventoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryMakes_QInventoryMakeId",
                table: "DealerInventories",
                column: "QInventoryMakeId",
                principalTable: "QInventoryMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventories_QInventoryModels_QInventoryModelId",
                table: "DealerInventories",
                column: "QInventoryModelId",
                principalTable: "QInventoryModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryMakes_QInventoryMakeId",
                table: "DealerInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventories_QInventoryModels_QInventoryModelId",
                table: "DealerInventories");

            migrationBuilder.DropIndex(
                name: "IX_DealerInventories_QInventoryModelId",
                table: "DealerInventories");

            migrationBuilder.RenameColumn(
                name: "QInventoryModelOther",
                table: "DealerInventories",
                newName: "ModelOther");

            migrationBuilder.RenameColumn(
                name: "QInventoryModelOptionOther",
                table: "DealerInventories",
                newName: "ModelOptionOther");

            migrationBuilder.RenameColumn(
                name: "QInventoryModelId",
                table: "DealerInventories",
                newName: "ModelInfoId");

            migrationBuilder.RenameColumn(
                name: "QInventoryMakeOther",
                table: "DealerInventories",
                newName: "MakeOther");

            migrationBuilder.RenameColumn(
                name: "QInventoryMakeId",
                table: "DealerInventories",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_DealerInventories_QInventoryMakeId",
                table: "DealerInventories",
                newName: "IX_DealerInventories_ModelId");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "DealerInventories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventories_MakeId",
                table: "DealerInventories",
                column: "MakeId");

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
        }
    }
}
