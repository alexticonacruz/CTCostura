using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCos_001.Migrations
{
    /// <inheritdoc />
    public partial class pagoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagoPedidosDbSet",
                columns: table => new
                {
                    pagoPedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    acuenta = table.Column<decimal>(type: "TEXT", nullable: false),
                    saldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    total = table.Column<decimal>(type: "TEXT", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoPedidosDbSet", x => x.pagoPedidoId);
                    table.ForeignKey(
                        name: "FK_PagoPedidosDbSet_pedidosDbSet_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "pedidosDbSet",
                        principalColumn: "pedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagoPedidosDbSet_pedidoId",
                table: "PagoPedidosDbSet",
                column: "pedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagoPedidosDbSet");
        }
    }
}
