using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    public partial class Mecanico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");
        }
    }
}
