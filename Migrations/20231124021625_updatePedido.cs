using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCos_001.Migrations
{
    /// <inheritdoc />
    public partial class updatePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clienteId",
                table: "pedidosDbSet",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pedidosDbSet_clienteId",
                table: "pedidosDbSet",
                column: "clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidosDbSet_ClientesDbSet_clienteId",
                table: "pedidosDbSet",
                column: "clienteId",
                principalTable: "ClientesDbSet",
                principalColumn: "clienteId",
                onDelete: ReferentialAction.Cascade);
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidosDbSet_ClientesDbSet_clienteId",
                table: "pedidosDbSet");

            migrationBuilder.DropIndex(
                name: "IX_pedidosDbSet_clienteId",
                table: "pedidosDbSet");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "pedidosDbSet");
        }
    }
}
