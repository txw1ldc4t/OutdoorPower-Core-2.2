using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class UpdateDealerInventoryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventoryImages_DealerInventories_DealerInventoryId",
                table: "DealerInventoryImages");

            migrationBuilder.AlterColumn<int>(
                name: "DealerInventoryId",
                table: "DealerInventoryImages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventoryImages_DealerInventories_DealerInventoryId",
                table: "DealerInventoryImages",
                column: "DealerInventoryId",
                principalTable: "DealerInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInventoryImages_DealerInventories_DealerInventoryId",
                table: "DealerInventoryImages");

            migrationBuilder.AlterColumn<int>(
                name: "DealerInventoryId",
                table: "DealerInventoryImages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInventoryImages_DealerInventories_DealerInventoryId",
                table: "DealerInventoryImages",
                column: "DealerInventoryId",
                principalTable: "DealerInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
