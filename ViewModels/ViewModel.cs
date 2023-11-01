using SistemaCos_001.Models;


namespace SistemaCos_001.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<Categoria> categorias { get; } 
        public IEnumerable<Producto> productos { get; }
        public Producto productoClass { get; set; }
        public ViewModel(IEnumerable <Categoria> _categoria, IEnumerable<Producto> _producto, Producto _productoClass) 
        {
            categorias = _categoria;
            productos = _producto;
            productoClass = _productoClass;
        }
        public ViewModel()
        {
            
        }
    }
}
