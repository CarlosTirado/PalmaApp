using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PalmApp");

            migrationBuilder.CreateTable(
                name: "Cultivo",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    FechaSiembra = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tercero",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    NumeroHectareas = table.Column<decimal>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    CultivoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_Cultivo_CultivoId",
                        column: x => x.CultivoId,
                        principalSchema: "PalmApp",
                        principalTable: "Cultivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palma",
                schema: "PalmApp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consecutivo = table.Column<string>(nullable: true),
                    Altura = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaSiembra = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    LoteId = table.Column<long>(nullable: false),
                    Lote2Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palma_Lote_Lote2Id",
                        column: x => x.Lote2Id,
                        principalSchema: "PalmApp",
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Palma_Lote_LoteId",
                        column: x => x.LoteId,
                        principalSchema: "PalmApp",
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_CultivoId",
                schema: "PalmApp",
                table: "Lote",
                column: "CultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Palma_Lote2Id",
                schema: "PalmApp",
                table: "Palma",
                column: "Lote2Id");

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

            migrationBuilder.DropTable(
                name: "Tarea",
                schema: "PalmApp");

            migrationBuilder.DropTable(
                name: "Tercero",
                schema: "PalmApp");

            migrationBuilder.DropTable(
                name: "Lote",
                schema: "PalmApp");

            migrationBuilder.DropTable(
                name: "Cultivo",
                schema: "PalmApp");
        }
    }
}
