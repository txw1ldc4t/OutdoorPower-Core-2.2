using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class UpdateDealerInventory_SetIsSoldNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSold",
                table: "DealerInventories",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSold",
                table: "DealerInventories",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
