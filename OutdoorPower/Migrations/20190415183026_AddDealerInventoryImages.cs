using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutdoorPower.Migrations
{
    public partial class AddDealerInventoryImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DealerInventoryImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(nullable: true),
                    DealerInventoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerInventoryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerInventoryImages_DealerInventories_DealerInventoryId",
                        column: x => x.DealerInventoryId,
                        principalTable: "DealerInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealerInventoryImages_DealerInventoryId",
                table: "DealerInventoryImages",
                column: "DealerInventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerInventoryImages");
        }
    }
}
