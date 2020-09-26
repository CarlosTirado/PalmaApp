using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CamposDecimalesEnPalmasYLote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Altura",
                schema: "PalmApp",
                table: "Palma",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "NumeroHectareas",
                schema: "PalmApp",
                table: "Lote",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Altura",
                schema: "PalmApp",
                table: "Palma",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "NumeroHectareas",
                schema: "PalmApp",
                table: "Lote",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
