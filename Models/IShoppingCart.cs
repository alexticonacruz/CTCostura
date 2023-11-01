namespace SistemaCos_001.Models
{
    public interface IShoppingCart
    {
        //void AddToCart(Pie pie);
        void AddToCart(stock producto);
        //int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        string cantidadCarrito(List<ShoppingCartItem> listItems);


    }
}
