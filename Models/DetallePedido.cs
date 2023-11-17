using Newtonsoft.Json;

namespace SistemaCos_001.Models
{
    public class DetallePedido
    {
        public int detallePedidoId { get; set; }
        public int pedidoId { get; set; }
        [JsonProperty("id")]
        public int productoId { get; set; }
        [JsonProperty("cantidad")]
        public int cantidad { get; set; }
        [JsonProperty("total")]
        public int total { get; set; }
        public Pedido Pedido { get; set; } = default!;
        public Producto Producto { get; set; } = default!;
    }
}
