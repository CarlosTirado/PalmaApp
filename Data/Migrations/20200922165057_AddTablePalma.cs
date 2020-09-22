using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTablePalma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                schema: "PalmApp",
                table: "Tarea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Palma",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consecutivo = table.Column<string>(nullable: true),
                    Altura = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaSiembra = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    LoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palma_Lote_LoteId",
                        column: x => x.LoteId,
                        principalSchema: "PalmApp",
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palma_LoteId",
                schema: "PalmApp",
                table: "Palma",
                column: "LoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Palma",
                schema: "PalmApp");

            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "PalmApp",
                table: "Tarea");
        }
    }
}
