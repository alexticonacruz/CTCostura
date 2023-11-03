using SistemaCos_001.Models;


namespace SistemaCos_001.ViewModels
{
    public class ProductoListViewModel
    {
        public IEnumerable<Producto> productos { get; }
        public IEnumerable<Categoria> categorias { get; }
        public IEnumerable <stock> stocks { get; set; }
        public ProductoListViewModel(IEnumerable<Categoria> categorias,IEnumerable<Producto> productos, IEnumerable<stock> stocks)
        {
            this.productos = productos;
            this.categorias = categorias;
            this.stocks = stocks;
        }
    }
}
