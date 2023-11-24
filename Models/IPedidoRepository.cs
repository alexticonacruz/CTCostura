namespace SistemaCos_001.Models
{
    public interface IPedidoRepository
    {
        void agregar(Pedido newPedido);
        IEnumerable<Pedido> GetAll { get; }
        Pedido GetById(int id);
        void update(Pedido newPedido);
    }
}
