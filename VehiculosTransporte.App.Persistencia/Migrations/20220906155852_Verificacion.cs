using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    public partial class Verificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MecanicoId = table.Column<int>(type: "int", nullable: false),
                    Vehiculo = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verificaciones_MecanicoId",
                table: "Verificaciones",
                column: "MecanicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verificaciones");
        }
    }
}
