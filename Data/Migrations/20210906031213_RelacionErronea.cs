using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RelacionErronea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palma_Lote_Lote2Id",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.DropIndex(
                name: "IX_Palma_Lote2Id",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.DropColumn(
                name: "Lote2Id",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.AddColumn<long>(
                name: "LoteId1",
                schema: "PalmApp",
                table: "Palma",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Palma_LoteId1",
                schema: "PalmApp",
                table: "Palma",
                column: "LoteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Palma_Lote_LoteId1",
                schema: "PalmApp",
                table: "Palma",
                column: "LoteId1",
                principalSchema: "PalmApp",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palma_Lote_LoteId1",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.DropIndex(
                name: "IX_Palma_LoteId1",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.DropColumn(
                name: "LoteId1",
                schema: "PalmApp",
                table: "Palma");

            migrationBuilder.AddColumn<long>(
                name: "Lote2Id",
                schema: "PalmApp",
                table: "Palma",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Palma_Lote2Id",
                schema: "PalmApp",
                table: "Palma",
                column: "Lote2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Palma_Lote_Lote2Id",
                schema: "PalmApp",
                table: "Palma",
                column: "Lote2Id",
                principalSchema: "PalmApp",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
