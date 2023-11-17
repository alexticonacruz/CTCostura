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

        public void UpdateStocks(List<ShoppingCartItem> StockITems)
        {
            foreach (ShoppingCartItem? shoppingCartItem in StockITems)
            {
                var objeto = _cTCosturaDbContext.StocksDbSet.FirstOrDefault(s => s.stockId == shoppingCartItem.Producto.stockId);
                if (objeto != null)
                {
                    objeto.cantidad = objeto.cantidad - shoppingCartItem.Amount;
                    _cTCosturaDbContext.StocksDbSet.Update(objeto);
                    
                }
            }
            _cTCosturaDbContext.SaveChanges();
        }
        //public IEnumerable<stock> Ultimos()
        //{
        //    var stockMasRecientePorProducto = _cTCosturaDbContext.StocksDbSet
        //        .GroupBy(s => s.productoId)
        //        .Select(group => group.OrderByDescending(s => s.fecha).First())
        //        .Select(s => new stock
        //        {
        //            productoId = s.productoId,
        //            stockId = s.stockId,
        //            precioMayor = s.precioMayor
        //        })
        //        .ToList();

        //    return stockMasRecientePorProducto;
        //}
        public IEnumerable<stock> Ultimos()
        {
            var stockMasRecientePorProducto = _cTCosturaDbContext.StocksDbSet
                .Where(s => s.fecha == _cTCosturaDbContext.StocksDbSet
                    .Where(inner => inner.productoId == s.productoId)
                    .Max(inner => inner.fecha))
                .ToList();

            return stockMasRecientePorProducto;
        }


    }
}
