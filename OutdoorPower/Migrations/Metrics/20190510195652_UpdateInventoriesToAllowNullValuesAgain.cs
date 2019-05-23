using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations.Metrics
{
    public partial class UpdateInventoriesToAllowNullValuesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "WholeSalePrice",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<short>(
                name: "Fuel",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "EngineHours",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "Condition",
                table: "Inventories",
                nullable: true,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WholeSalePrice",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Fuel",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngineHours",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Condition",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);
        }
    }
}
