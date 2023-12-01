namespace SistemaCos_001.Models
{
    public interface IpagoPedido
    {
        void agregar(pagoPedido newPago);
        IEnumerable<pagoPedido> GetPedidos { get; }
        decimal ultimoPago(int id);
    }
}
