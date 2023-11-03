using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;

namespace SistemaCos_001.Controllers
{
    [Authorize]
    public class VentaController : Controller
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IProductoRepository _productoRepository;
        private readonly IStockRepository _stockRepository;

        public VentaController(IVentaRepository ventaRepository, IShoppingCart shoppingCart, IProductoRepository productoRepository, IStockRepository stockRepository)
        {
            _ventaRepository = ventaRepository;
            _shoppingCart = shoppingCart;
            _productoRepository = productoRepository;
            _stockRepository = stockRepository;
        }

        public IActionResult Checkout()//GET, default.
        {

            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Venta venta)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            int dato = items.Count();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some Products first");
            }

            if (ModelState.IsValid)
            {
                _ventaRepository.CreateOrder(venta);
                _stockRepository.UpdateStocks(_shoppingCart.ShoppingCartItems);
                string texto = _ventaRepository.detalleOrden(venta, _productoRepository.AllProductos);
                string number = venta.PhoneNumber;
                _ventaRepository.correoSend(texto, venta.Email);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete",new { texto = texto, number = number });
            }
            return View(venta);
        }

        public IActionResult CheckoutComplete(string texto, string number)
        {
            var informacion = TempData["Informacion"] as string;
            ViewBag.CheckoutCompleteMessage = texto;
            ViewBag.numero = number;
            ViewBag.idTransaccion = informacion;
            return View();
        }

        
    }
}
