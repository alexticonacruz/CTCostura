using SistemaCos_001.Models;

namespace SistemaCos_001.ViewModels
{
    public class pagoPedidoViewModel
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public pagoPedido pagoPedido { get; set; }
        public Pedido newPedido { get; set; }
    }
}
