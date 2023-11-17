namespace SistemaCos_001.Models
{
    public interface IStockRepository
    {
        void saveStock(stock newStocke);
        IEnumerable<stock> GetStocks { get;}
        IEnumerable<stock> SearchProducto(string searchQuery);
        IEnumerable<stock> Ultimos();
        void UpdateStocks(List<ShoppingCartItem> StockITems);
    }
}
