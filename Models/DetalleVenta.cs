namespace SistemaCos_001.Models
{
    public class DetalleVenta
    {
        public int detalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int stockId { get; set; }
        public stock Stock { get; set; } = default!;
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public Venta Venta { get; set; } = default!;
    }
}
