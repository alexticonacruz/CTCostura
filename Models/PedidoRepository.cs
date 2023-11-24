using Microsoft.EntityFrameworkCore;

namespace SistemaCos_001.Models
{
    public class PedidoRepository:IPedidoRepository
    {
        private readonly CTCosturaDbContext _context;
        
        public PedidoRepository(CTCosturaDbContext context)
        {
            _context = context;
        }
        public void agregar(Pedido newPedido)
        {
            newPedido.fecha = DateTime.Now;
            newPedido.estado = "proceso";
            newPedido.descuento = 0;
            newPedido.jsonCadena = "";
            _context.Add(newPedido);
            _context.SaveChanges();
        }
        public IEnumerable<Pedido> GetAll => _context.pedidosDbSet.Include(cliente => cliente.Cliente).ToList();

        public Pedido? GetById(int id)
        {
            return _context.pedidosDbSet
                .Include(p => p.Cliente) // Cargar información del cliente relacionado
                .Include(p => p.DetallePedidos) // Cargar detalles del pedido relacionados
                .ThenInclude(dp => dp.Producto)
                .SingleOrDefault(p => p.pedidoId == id);
        }

    }
}
