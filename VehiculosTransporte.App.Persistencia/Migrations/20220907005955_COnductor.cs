using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    public partial class COnductor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Propietario_VehiculoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Propietario_VehiculoId",
                table: "Personas",
                column: "Propietario_VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_VehiculoId",
                table: "Personas",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_Propietario_VehiculoId",
                table: "Personas",
                column: "Propietario_VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_VehiculoId",
                table: "Personas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_Propietario_VehiculoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_VehiculoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Propietario_VehiculoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_VehiculoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Propietario_VehiculoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Personas");
        }
    }
}
