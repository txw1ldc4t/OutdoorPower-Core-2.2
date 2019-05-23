using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations.Metrics
{
    public partial class InventoryRemoveAmountSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountSold",
                table: "Inventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountSold",
                table: "Inventories",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
