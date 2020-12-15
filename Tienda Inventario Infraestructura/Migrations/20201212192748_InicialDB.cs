using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaInventario.WebApp.Migrations
{
    public partial class InicialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaConsolidacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDespachado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    codigoFactura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ordenVentaId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producto_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoPedidos_OrdenVentas_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPedidos_OrdenVentaId",
                table: "ProductoPedidos",
                column: "OrdenVentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoPedidos");

            migrationBuilder.DropTable(
                name: "OrdenVentas");
        }
    }
}
