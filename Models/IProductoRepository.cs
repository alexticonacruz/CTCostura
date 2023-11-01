//using SistemaCos_001.ViewModels;

namespace SistemaCos_001.Models
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> AllProductos { get; } // por el momento esto si
        IEnumerable<Producto> productosList { get; }
        Producto? GetProductosById(int idProducto);//si

        void CreateProducto (Producto producto);
        //void agregarProducto(ViewModel model);
        IEnumerable<Producto> filtroDelete { get; }
        public Producto GetById(int id);
        void deleteUpdate (Producto producto);

        IEnumerable<Producto> SearchProducto(string searchQuery);
    }
}
