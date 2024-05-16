using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCLiente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCLiente);
                });

            migrationBuilder.CreateTable(
                name: "Sorteos",
                columns: table => new
                {
                    idSorteo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroSorteo = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteos", x => x.idSorteo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idSorteo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCLiente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Sorteos_idSorteo",
                        column: x => x.idSorteo,
                        principalTable: "Sorteos",
                        principalColumn: "idSorteo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sorteos_numeroSorteo",
                table: "Sorteos",
                column: "numeroSorteo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idCliente",
                table: "Usuarios",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idSorteo",
                table: "Usuarios",
                column: "idSorteo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Sorteos");
        }
    }
}
