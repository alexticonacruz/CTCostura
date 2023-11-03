namespace SistemaCos_001.Models
{
    public interface IVentaRepository
    {
        void CreateOrder(Venta order);
        void correoSend(string informacion, string Email);
        string detalleOrden(Venta order, IEnumerable<Producto> productosList);
        List<string> ventasActual();

    }
}
