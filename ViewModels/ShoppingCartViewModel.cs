using SistemaCos_001.Models;

namespace SistemaCos_001.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal, IEnumerable<Producto> productos)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
            this.productos = productos;
        }
        public ShoppingCartViewModel()
        {
            
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
        public IEnumerable<Producto> productos { get;}
    }
}
