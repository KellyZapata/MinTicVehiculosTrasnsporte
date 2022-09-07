using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiracion_tenicomecanica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiracion_soat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiracion_seguro_contractual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiracion_extra_contractual = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero_Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MecanicoId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Nivel_Aceite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel_Liquido_frenos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel_Refrigerante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel_Liquido_direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verificaciones_Personas_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verificaciones_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerificacionId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repuestos_Verificaciones_VerificacionId",
                        column: x => x.VerificacionId,
                        principalTable: "Verificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_VehiculoId",
                table: "Personas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Repuestos_VerificacionId",
                table: "Repuestos",
                column: "VerificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Verificaciones_MecanicoId",
                table: "Verificaciones",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Verificaciones_VehiculoId",
                table: "Verificaciones",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repuestos");

            migrationBuilder.DropTable(
                name: "Verificaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
