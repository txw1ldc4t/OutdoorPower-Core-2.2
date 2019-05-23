using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class GeneralUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "decimal(18,2)",
                table: "DealerInventories",
                newName: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "WholeSalePrice",
                table: "DealerInventories",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WholeSalePrice",
                table: "DealerInventories");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "DealerInventories",
                newName: "decimal(18,2)");
        }
    }
}
