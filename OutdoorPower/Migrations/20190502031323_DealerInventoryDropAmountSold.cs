using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class DealerInventoryDropAmountSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountSold",
                table: "DealerInventories",
                newName: "WholeSalePrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WholeSalePrice",
                table: "DealerInventories",
                newName: "AmountSold");
        }
    }
}
