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
            newPedido.fechaEntrega = DateTime.Now;
            newPedido.fecha = DateTime.Now;
            newPedido.estado = "pendiente";
            newPedido.descuento = 0;
            newPedido.montoTotal = 100;
            newPedido.monto = 100;
            newPedido.jsonCadena = "";
            _context.Add(newPedido);
            _context.SaveChanges();
        }
    }
}
