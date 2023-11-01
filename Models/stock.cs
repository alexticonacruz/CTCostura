namespace SistemaCos_001.Models
{
    public class stock
    {
        public int stockId { get; set; }
        public int productoId { get; set; }
        public  Producto Producto { get; set; } = default!;
        public int cantidad { get; set; }
        public decimal precioMayor { get; set; }
        public decimal precioMenor { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }

    }
}
