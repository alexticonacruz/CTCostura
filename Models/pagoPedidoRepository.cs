namespace SistemaCos_001.Models
{
    public class pagoPedidoRepository:IpagoPedido
    {
        private readonly CTCosturaDbContext _context;
        public pagoPedidoRepository(CTCosturaDbContext cTCosturaDbContext)
        {
            _context = cTCosturaDbContext;
        }
        public void agregar (pagoPedido newPago)
        {
            _context.PagoPedidosDbSet.Add(newPago);
            _context.SaveChanges();
        }
    }
}
