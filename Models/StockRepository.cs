using Microsoft.EntityFrameworkCore;

namespace SistemaCos_001.Models
{
    public class StockRepository:IStockRepository
    {
        private readonly CTCosturaDbContext _cTCosturaDbContext;
        public StockRepository(CTCosturaDbContext cTCosturaDbContext)
        {
            _cTCosturaDbContext = cTCosturaDbContext;
        }

        public void saveStock(stock newStock)
        {
            newStock.fecha = DateTime.Now;
            _cTCosturaDbContext.StocksDbSet.Add(newStock);
            _cTCosturaDbContext.SaveChanges();
        }
        public IEnumerable<stock> GetStocks => _cTCosturaDbContext.StocksDbSet.Include(s => s.Producto).ToList();
        /* Serach */
        public IEnumerable<stock> SearchProducto(string searchQuery)
        {
            return _cTCosturaDbContext.StocksDbSet.Where(p => p.Producto.modelo.Contains(searchQuery));
        }
    }
}
