using Microsoft.EntityFrameworkCore;

namespace SistemaCos_001.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly CTCosturaDbContext _cTCosturaDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(CTCosturaDbContext cTCosturaDbContext)
        {
            _cTCosturaDbContext = cTCosturaDbContext;
        }
        /*This method we didn't have on our interface, it is a static method
         * It will return me a fully created ShoppingCart
         * I am passing a services colletion
         * When the user visits the site this code is going to run and it's going to check if there is already
         * and ID called CartId available for the user.If not the will create a new GUID and restore the values as the CartId.
         * When the user is returning, we'll be able to find the existing CartId and we'll use that.
         */
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            CTCosturaDbContext context = services.GetService<CTCosturaDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public void AddToCart(stock producto)
        {
            var shoppingCartItem =
                    _cTCosturaDbContext.ShoppingCartItemsDbSet.SingleOrDefault(
                        s => s.Producto.productoId == producto.productoId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Producto = producto,
                    Amount = 1
                };

                _cTCosturaDbContext.ShoppingCartItemsDbSet.Add(shoppingCartItem);
            } 
            else
            {
                shoppingCartItem.Amount++;
            }
            _cTCosturaDbContext.SaveChanges();
        }
        
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                        _cTCosturaDbContext.ShoppingCartItemsDbSet.Where(c => c.ShoppingCartId == ShoppingCartId)
                            .Include(s => s.Producto)
                            .ToList();
        }
        
        //este borra el carrito

        public void ClearCart()
        {
            var cartItems = _cTCosturaDbContext
                .ShoppingCartItemsDbSet
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _cTCosturaDbContext.ShoppingCartItemsDbSet.RemoveRange(cartItems);

            _cTCosturaDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _cTCosturaDbContext.ShoppingCartItemsDbSet
                .Include(s => s.Producto) // Carga ansiosa de Producto
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .ToList() // Convierte a objetos C#
                .Select(c => c.Producto.precioMenor * c.Amount) // Calcula el precio por cantidad
                .Sum(); // Suma los totales
            return total;
        }


        public string cantidadCarrito(List<ShoppingCartItem> listItems)
        {
            int contador = 0;
            foreach (var item in listItems)
            {
                contador += item.Amount;
            }
            return contador.ToString();
        }
    }
}
