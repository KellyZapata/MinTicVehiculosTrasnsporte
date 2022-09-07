using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    public partial class conductor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Propietario_VehiculoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Propietario_VehiculoId",
                table: "Personas",
                column: "Propietario_VehiculoId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_Propietario_VehiculoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Propietario_VehiculoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Propietario_VehiculoId",
                table: "Personas");
        }
    }
}
