namespace SistemaCos_001.Models
{
    public interface IClienteRepository
    {
        void agregar(Cliente newCliente);
        IEnumerable<Cliente> GetAll { get; }
    }
}
