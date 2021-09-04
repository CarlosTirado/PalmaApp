using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddAlertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerta",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Asunto = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Adjunto = table.Column<byte[]>(nullable: true),
                    CultivoId = table.Column<long>(nullable: true),
                    LoteId = table.Column<long>(nullable: true),
                    PalmaId = table.Column<long>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_Cultivo_CultivoId",
                        column: x => x.CultivoId,
                        principalSchema: "PalmApp",
                        principalTable: "Cultivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Lote_LoteId",
                        column: x => x.LoteId,
                        principalSchema: "PalmApp",
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Palma_PalmaId",
                        column: x => x.PalmaId,
                        principalSchema: "PalmApp",
                        principalTable: "Palma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlertaSeguimiento",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertaId = table.Column<long>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Adjunto = table.Column<byte[]>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertaSeguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertaSeguimiento_Alerta_AlertaId",
                        column: x => x.AlertaId,
                        principalSchema: "PalmApp",
                        principalTable: "Alerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_CultivoId",
                schema: "PalmApp",
                table: "Alerta",
                column: "CultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_LoteId",
                schema: "PalmApp",
                table: "Alerta",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_PalmaId",
                schema: "PalmApp",
                table: "Alerta",
                column: "PalmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertaSeguimiento_AlertaId",
                schema: "PalmApp",
                table: "AlertaSeguimiento",
                column: "AlertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertaSeguimiento",
                schema: "PalmApp");

            migrationBuilder.DropTable(
                name: "Alerta",
                schema: "PalmApp");
        }
    }
}
