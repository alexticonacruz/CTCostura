namespace SistemaCos_001.Models
{
    public class ClienteRepository:IClienteRepository
    {
        private readonly CTCosturaDbContext _context;
        public ClienteRepository(CTCosturaDbContext context)
        {

            _context = context;

        }
        public void agregar(Cliente newCliente)
        {
            _context.ClientesDbSet.Add(newCliente);
            _context.SaveChanges();
        }
        public IEnumerable<Cliente> GetAll => _context.ClientesDbSet.ToList();
    }
}
