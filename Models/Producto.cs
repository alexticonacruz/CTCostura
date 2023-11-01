namespace SistemaCos_001.Models
{
    public class Producto
    {
        public int productoId { get; set; }
        public string modelo { get; set; }
        public string cuello { get; set; }
        public string tela { get; set; }
        public string manga { get; set; }
        public string color { get; set; }
        public string  talla { get; set; }
        public string genero { get; set; }
        public int categoriaId { get; set; }
        public bool estado { get; set; }
        public string urlImagen { get; set; }
        public Categoria Categoria { get; set; } = default!;

    }
}
