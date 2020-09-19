using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTableLotes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CultivoId",
                schema: "PalmApp",
                table: "Lote",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Lote_CultivoId",
                schema: "PalmApp",
                table: "Lote",
                column: "CultivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Cultivo_CultivoId",
                schema: "PalmApp",
                table: "Lote",
                column: "CultivoId",
                principalSchema: "PalmApp",
                principalTable: "Cultivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Cultivo_CultivoId",
                schema: "PalmApp",
                table: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_Lote_CultivoId",
                schema: "PalmApp",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "CultivoId",
                schema: "PalmApp",
                table: "Lote");
        }
    }
}
