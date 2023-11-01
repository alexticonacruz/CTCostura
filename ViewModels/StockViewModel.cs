using SistemaCos_001.Models;

namespace SistemaCos_001.ViewModels
{
    public class StockViewModel
    {
        public IEnumerable<Producto> listProductos { get; }
        public stock newStock { get; set; }
        public StockViewModel(IEnumerable<Producto> listProductos, stock newStock)
        {
            this.listProductos = listProductos;
            this.newStock = newStock;
        }
        public StockViewModel()
        {
            
        }
    }
}
