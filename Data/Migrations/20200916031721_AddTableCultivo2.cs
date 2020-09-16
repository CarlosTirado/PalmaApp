using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTableCultivo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivos",
                table: "Cultivos");

            migrationBuilder.RenameTable(
                name: "Cultivos",
                newName: "Cultivo",
                newSchema: "PalmApp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivo",
                schema: "PalmApp",
                table: "Cultivo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivo",
                schema: "PalmApp",
                table: "Cultivo");

            migrationBuilder.RenameTable(
                name: "Cultivo",
                schema: "PalmApp",
                newName: "Cultivos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivos",
                table: "Cultivos",
                column: "Id");
        }
    }
}
