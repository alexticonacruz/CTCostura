namespace SistemaCos_001.Models
{
    public class Pedido
    {
        public int pedidoId { get; set; }
        public  DateTime fecha { get; set; }
        public Decimal monto { get; set; }
        public Decimal montoTotal { get; set; }
        public Decimal? descuento { get; set; }
        public DateTime fechaEntrega { get; set; }
        public List<DetallePedido>? DetallePedidos { get; set; }
        public string? jsonCadena { get; set; }
        public string? estado { get; set; }

    }
}
