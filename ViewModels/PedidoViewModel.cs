using SistemaCos_001.Models;
namespace SistemaCos_001.ViewModels
{
    public class PedidoViewModel
    {
        public IEnumerable<Producto> productos { get;}
        public IEnumerable<Cliente> clientes { get; }
        public Pedido newPedido { get; set; }
        public Cliente newCliente { get; set; }
        public PedidoViewModel(IEnumerable<Producto> listProductos, Pedido newPedidos,Cliente cliente, IEnumerable<Cliente> clientes)
        {
            this.newPedido = newPedidos;
            productos = listProductos;  
            newCliente = cliente;   
            this.clientes = clientes;
        }
        public PedidoViewModel()
        {
            
        }
    }
}
