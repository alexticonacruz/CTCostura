namespace SistemaCos_001.Models
{
    public class pagoPedido
    {
        public int pagoPedidoId { get; set; }
        public int pedidoId { get; set; }
        public decimal acuenta { get; set; }
        public decimal saldo { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
        public Pedido Pedido { get; set; } = default!;
        public Cliente Cliente { get; set; } = default!;

    }
}
