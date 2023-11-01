using SistemaCos_001.Models;


namespace SistemaCos_001.ViewModels
{
    public class ProductoListViewModel
    {
        public IEnumerable<Producto> productos { get; }
        public IEnumerable<Categoria> categorias { get; }
        public ProductoListViewModel(IEnumerable<Categoria> categorias,IEnumerable<Producto> productos)
        {
            this.productos = productos;
            this.categorias = categorias;

        }
    }
}
