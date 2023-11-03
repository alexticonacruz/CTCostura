namespace SistemaCos_001.Models
{
    public interface IStockRepository
    {
        void saveStock(stock newStocke);
        IEnumerable<stock> GetStocks { get;}
        IEnumerable<stock> SearchProducto(string searchQuery);
        void UpdateStocks(List<ShoppingCartItem> StockITems);
    }
}
