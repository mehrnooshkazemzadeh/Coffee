using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeService.Migrations
{
    public partial class CretaeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Str");

            migrationBuilder.CreateTable(
                name: "CoffeeStores",
                schema: "Str",
                columns: table => new
                {
                    CoffeeStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Poststatus = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecievedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeStores", x => x.CoffeeStoreId);
                    table.ForeignKey(
                        name: "FK_CoffeeStores_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalSchema: "Pdb",
                        principalTable: "Coffees",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeStores_CoffeeId",
                schema: "Str",
                table: "CoffeeStores",
                column: "CoffeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeStores",
                schema: "Str");
        }
    }
}
