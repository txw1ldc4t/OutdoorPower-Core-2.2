using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class AddedEngineModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(maxLength: 150, nullable: false),
                    Power = table.Column<string>(maxLength: 30, nullable: true),
                    Cooling = table.Column<string>(maxLength: 20, nullable: true),
                    Carburetor = table.Column<string>(maxLength: 100, nullable: true),
                    EngineModel = table.Column<string>(maxLength: 50, nullable: true),
                    ModelNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Displacement = table.Column<string>(maxLength: 10, nullable: true),
                    Fuel = table.Column<string>(maxLength: 20, nullable: true),
                    FuelPump = table.Column<string>(maxLength: 100, nullable: true),
                    OilPump = table.Column<string>(maxLength: 70, nullable: true),
                    Starter = table.Column<string>(maxLength: 75, nullable: true),
                    Belts = table.Column<string>(maxLength: 100, nullable: true),
                    Cylinders = table.Column<string>(maxLength: 60, nullable: true),
                    Governor = table.Column<string>(maxLength: 100, nullable: true),
                    IdleSpeed = table.Column<string>(maxLength: 20, nullable: true),
                    Battery = table.Column<string>(maxLength: 20, nullable: true),
                    BatteryCharging = table.Column<string>(maxLength: 20, nullable: true),
                    BatteryChargingOutput = table.Column<string>(maxLength: 20, nullable: true),
                    Fuses = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");
        }
    }
}
