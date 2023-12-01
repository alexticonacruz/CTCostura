using SistemaCos_001.Models;
namespace SistemaCos_001.ViewModels
{
    public class PedidoViewModel
    {
        public IEnumerable<Producto> productos { get; set; }
        public IEnumerable<Cliente> clientes { get; set; }
        public Pedido newPedido { get; set; }
        public Cliente newCliente { get; set; }
        public pagoPedido newPago { get; set; }
        
    }
}
