using SistemaCos_001.Models;
namespace SistemaCos_001.ViewModels
{
    public class PedidoViewModel
    {
        public IEnumerable<Producto> productos { get;}
        public Pedido newPedido { get; set; }
        public PedidoViewModel(IEnumerable<Producto> listProductos, Pedido newPedidos)
        {
            this.newPedido = newPedidos;
            productos = listProductos;  
        }
        public PedidoViewModel()
        {
            
        }
    }
}
