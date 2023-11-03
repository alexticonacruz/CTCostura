using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;
using SistemaCos_001.ViewModels;

namespace SistemasWeb01.Controllers
{
    public class ShoppingCartController : Controller
    {
        
        private readonly IStockRepository _stockRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IProductoRepository _productoRepository;

        public ShoppingCartController( IShoppingCart shoppingCart, IStockRepository stockRepository,IProductoRepository productoRepository)
        {
           
            _shoppingCart = shoppingCart;
            _stockRepository = stockRepository;
            _productoRepository = productoRepository;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            ViewBag.Items = _shoppingCart.cantidadCarrito(items);
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal(),_productoRepository.AllProductos);

            return View(shoppingCartViewModel);
        }
        
        
        public RedirectToActionResult AddToShoppingCart(int productoId)
        {
            var selectedProducto = _stockRepository.GetStocks.FirstOrDefault(s => s.stockId == productoId);

            if (selectedProducto != null)
            {
                _shoppingCart.AddToCart(selectedProducto);
            }
            return RedirectToAction("Index");
        }

        //public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        //{
        //    var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

        //    if (selectedPie != null)
        //    {
        //        _shoppingCart.RemoveFromCart(selectedPie);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
