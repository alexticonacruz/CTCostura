using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using SistemaCos_001.Models;


namespace SistemaCos_001.Models
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly CTCosturaDbContext _cTCosturaDbContext;

        public ProductoRepository(CTCosturaDbContext bethesdaPieShopDbContext)
        {
            _cTCosturaDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<Producto> AllProductos
        {
            get
            {
                return _cTCosturaDbContext.ProductosDbSet.Include(c => c.Categoria);
            }
        }

       

        public Producto? GetProductosById(int idProducto)
        {
            return _cTCosturaDbContext.ProductosDbSet.FirstOrDefault(p => p.productoId == idProducto);
        }

        public IEnumerable<Producto> SearchProductos(string searchQuery)
        {
            throw new NotImplementedException();
        }
        /* crea un nuevo producto*/
        public void CreateProducto(Producto _producto)
        {
            _cTCosturaDbContext.ProductosDbSet.Add(_producto);
            _cTCosturaDbContext.SaveChanges();

        }
        /* LLama a todos los productos */
        public IEnumerable<Producto> productosList => _cTCosturaDbContext.ProductosDbSet.ToList();
        public IEnumerable<Producto> filtroDelete => _cTCosturaDbContext.ProductosDbSet.Where(p => p.estado == true).ToList();
          

        public Producto GetById(int id)
        {
            return _cTCosturaDbContext.ProductosDbSet.FirstOrDefault(p => p.productoId == id);
        }
        public void deleteUpdate(Producto _producto)
        {
            _cTCosturaDbContext.ProductosDbSet.Update(_producto);
            _cTCosturaDbContext.SaveChanges();
        }
        /* Serach */
        public IEnumerable<Producto> SearchProducto(string searchQuery)
        {
            return _cTCosturaDbContext.ProductosDbSet.Where(p => p.modelo.Contains(searchQuery));
        }
        
    }
}
