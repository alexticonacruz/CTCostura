using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCos_001.Migrations
{
    /// <inheritdoc />
    public partial class pedidoTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedidosDbSet",
                columns: table => new
                {
                    pedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    montoTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    descuento = table.Column<decimal>(type: "TEXT", nullable: true),
                    fechaEntrega = table.Column<DateTime>(type: "TEXT", nullable: false),
                    jsonCadena = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidosDbSet", x => x.pedidoId);
                });

            migrationBuilder.CreateTable(
                name: "detallePedidosDbSet",
                columns: table => new
                {
                    detallePedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    productoId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedidosDbSet", x => x.detallePedidoId);
                    table.ForeignKey(
                        name: "FK_detallePedidosDbSet_ProductosDbSet_productoId",
                        column: x => x.productoId,
                        principalTable: "ProductosDbSet",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePedidosDbSet_pedidosDbSet_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "pedidosDbSet",
                        principalColumn: "pedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallePedidosDbSet_pedidoId",
                table: "detallePedidosDbSet",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedidosDbSet_productoId",
                table: "detallePedidosDbSet",
                column: "productoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallePedidosDbSet");

            migrationBuilder.DropTable(
                name: "pedidosDbSet");
        }
    }
}
